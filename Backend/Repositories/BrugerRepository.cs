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

    public User getUserID(int id)
    {
        var filter = Builders<User>.Filter.Eq("_id", id);
        return _brugerRepository.Find(filter).FirstOrDefault();
    }

    public User Login(string email)
    {
        var filter = Builders<User>.Filter.Eq("email", email);
        return _brugerRepository.Find(filter).FirstOrDefault();
        //samme kode som ovenfor, filter efter det man får ind i databasen, og få fat i den
        //vi tjekker kun for email ved login, dvs. kodeord er null
    }

    public void CreateUser(User user)
    {
        _brugerRepository.InsertOne(user);
    }
}