namespace Core;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]//samme som i annnce.cs
public class User
{
    public int UserId { get; set; }
    
    public string name { get; set; }
    public string password { get; set; }
    public string email { get; set; }
}