using Backend.Repositories.Interfaces;
using Core;
using MongoDB.Driver;

namespace Backend.Repositories;

public class BrugerRepository : IBrugerRepo
{
    private readonly IMongoCollection<User> _brugerRepository;
    
    public BrugerRepository()
    {
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("Clothplace");
        
        _brugerRepository = database.GetCollection<User>("Users");
    }

    public User getUserById(int id)
    {
        var filter = Builders<User>.Filter.Eq("_id", id);
        return _brugerRepository.Find(filter).FirstOrDefault();
    }

    /**
    public string getPasswordByName(string name)
    {
        var filter = Builders<User>.Filter.Eq("Name", name);
        return _BrugerRepository.Find(filter).FirstOrDefault();
    }
    **/
}