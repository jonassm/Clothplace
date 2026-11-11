namespace Core;

public class Annonce
{
    public int aID { get; set; }
    public string Name { get; set; }
    public string Beskrivelse { get; set; }
    public int Pris { get; set; }
    public bool BuyStatus { get; set; }
    public int LokationId { get; set; }
    public string? ImageURL { get; set; } // ? da ikke krav om billede
    public int OwnerID { get; set; }
    public int? BuyerId { get; set; } // int? da den ikke starter købt.
}
