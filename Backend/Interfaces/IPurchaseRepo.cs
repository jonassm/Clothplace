using Core;
namespace Backend.Repositories.Interfaces;

public interface IPurchaseRepo
{
    public List<Purchase> getPurchaseByBuyerId(int id);
}