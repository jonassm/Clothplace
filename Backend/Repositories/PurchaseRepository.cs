using Backend.Repositories.Interfaces;
using Core;
using MongoDB.Driver;

namespace Backend.Repositories;

public class PurchaseRepository : IPurchaseRepo
{
    private IMongoCollection<Purchase> _purchaseRepository;
    
    public PurchaseRepository()
    {
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("Clothplace");
        
        _purchaseRepository = database.GetCollection<Purchase>("Purchases");
        
    }
    
    public List<Purchase> getPurchaseByBuyerId(int id)
    {
        var filter = Builders<Purchase>.Filter.Eq("Buyer_Id", id);
        return _purchaseRepository.Find(filter).ToList();
    }
    
}