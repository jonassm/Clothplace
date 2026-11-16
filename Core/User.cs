namespace Core;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]//samme som i annnce.cs
public class User
{
    [BsonId] //definere vi bruger mongo _id til userid.
    public int UserId { get; set; }
    
    public string name { get; set; }
    public string password { get; set; }
    public string email { get; set; }
}