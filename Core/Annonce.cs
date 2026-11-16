using MongoDB.Bson.Serialization.Attributes;

namespace Core;

[BsonIgnoreExtraElements]
/*
 * Denne attribut siger til mongodb, at den ikke selv skal tilføje ekstra ting. Det er relevant, da
 * mongodb laver sin egen lange _id streng, som vi ikke kan bruge til noget. Men når vi laver en udiskrimnatorisk get funktion, brokker
 * systemet sig gevaldigt grundet denne header.
 */
public class Annonce
{
    public int aID { get; set; }
    public string Name { get; set; }
    public string Beskrivelse { get; set; }
    public string Kategori { get; set; }
    public string Stand { get; set; }
    public int Pris { get; set; }
    public bool BuyStatus { get; set; }
    public string? ImageURL { get; set; } // ? da ikke krav om billede

    public int UserId { get; set; } //id på brugeren der har lavet annoncen (User.UserId)
    public int? BuyerId { get; set; } // int? da den ikke starter købt.
    public string Lokation { get; set; }
}
