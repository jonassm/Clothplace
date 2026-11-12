using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Core;


//Vi samler cart i en klasse, så vi nemt kan dele den mellem marketplace/cart.
public class CartClass
{
    public List<Annonce> cart = new(); //init den nye liste til valgte items.

    public void AddItem(Annonce annonce)
    {
        if (!cart.Any(a => a.aID == annonce.aID))
            cart.Add(annonce); //tjek, at den annonce ikke allerede er i cart.
    }

    public void RemoveItem(Annonce annonce)
    {
        cart.RemoveAll(a => a.aID == annonce.aID);
        //fjerner "alle" men hvor alle kun er dem med det ID vi ønsker at fjerne, dvs reelt en remove 1 funktion.
    }
}