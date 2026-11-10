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
        //Laver tom filter (altså det hele) og sender til listen.
        return _annonceRepository.Find(Builders<Annonce>.Filter.Empty).ToList();
    }

    public void PutToggleBought(int aID)
    { 
        var filter = Builders<Annonce>.Filter.Eq(a => a.aID, aID);
        //Start med at finde den annonce vi skal ændre via ID.
        var annonce = _annonceRepository.Find(filter).FirstOrDefault();
        //Tag fat i den row i databasen.
        //her burde man lave prækondtion tjek for om den findes
        var toggle = Builders<Annonce>.Update
            .Set(a => a.BuyStatus, !annonce.BuyStatus);
        //Laver update til databasen, hvor vi sætter købstatus det modsatte (ergo !)
        _annonceRepository.UpdateOne(filter, toggle);
        //endelig kald til databasen.
    }

    public void DeleteAnnonce(int aID)
    {
        var filter = Builders<Annonce>.Filter.Eq(a => a.aID, aID);
        //samme kode som ovenfor, men da vi ikke skal ændre noget inde i den
        //behøver vi ikke definere var annonce.
        _annonceRepository.DeleteOne(filter);
        //slet den
    }
}