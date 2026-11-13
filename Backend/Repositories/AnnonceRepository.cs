using Backend.Repositories.Interfaces;
using Core;
using MongoDB.Driver;

namespace Backend.Repositories;

public class AnnonceRepository : IAnnonceRepo
{
    private readonly IMongoCollection<Annonce> _annonceRepository;
    
    public AnnonceRepository()
    {
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("Clothplace");
        
        _annonceRepository = database.GetCollection<Annonce>("Annonces");
        
    }

    public int GetNextId()
    {
        var latest = _annonceRepository
            .Find(Builders<Annonce>.Filter.Empty)
            .SortByDescending(a => a.aID)
            .FirstOrDefault();
        /*
         * Vi sortere hele listen ud fra det højeste tal først, og tager fat i det.
         * nedeunder tager vi det tal og plusser med 1, og sender tilbage til controlleren.
         */

        return (latest?.aID ?? 0) + 1;
        //Null tjek, så den allerførste der laver en annonce ikke borker databasen.
    }
    
    
    public void AddAnnonce(Annonce annonce)
    {
        _annonceRepository.InsertOne(annonce);
    }

    public List<Annonce> GetAllAnnonces()
    {
        //Vi skal have fat i alt der IKKE er købt.
        var filter = Builders<Annonce>.Filter.Eq(a => a.BuyStatus, false);
        return _annonceRepository.Find(filter).ToList();
    }

    public List<Annonce> GetSoldAnnonces(int userId)
    {
        //Alt brugeren selv har lagt op (UserId), som ER købt.
        var filter = Builders<Annonce>.Filter.Eq(a => a.UserId, userId)
                     & Builders<Annonce>.Filter.Eq(a => a.BuyStatus, true);
        return _annonceRepository.Find(filter).ToList();
    }

    public void DeleteAnnonce(int aID)
    {
        var filter = Builders<Annonce>.Filter.Eq(a => a.aID, aID);
        //samme kode som ovenfor, men da vi ikke skal ændre noget inde i den
        //behøver vi ikke definere var annonce.
        _annonceRepository.DeleteOne(filter);
        //slet den
    }

      public void BuyAnnonce(int aID, int buyerId)
    {
        var filter = Builders<Annonce>.Filter.Eq(a => a.aID, aID);
        var annonce = _annonceRepository.Find(filter).FirstOrDefault();
        //start med at finde den rette

        var changes = Builders<Annonce>.Update
            .Set(a => a.BuyStatus, true) //ændr buy status
            .Set(a => a.BuyerId, buyerId); //sæt buyerid
        
        _annonceRepository.UpdateOne(filter, changes);
    }
}