namespace Core;

public class Purchase
{
    public int PurchaseId { get; set; }
    public List<Annonce> ShoppingList { get; set; }
    public int AnnonceId { get; set; }
    public int BuyerId { get; set; }
}