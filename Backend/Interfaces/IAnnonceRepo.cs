using Core;

namespace Backend.Repositories.Interfaces;

public interface IAnnonceRepo
{
    public int GetNextId();
    public void AddAnnonce(Annonce annonce);

    public List<Annonce> GetAllAnnonces();

    public List<Annonce> GetSoldAnnonces(int userId);

    //public void PutToggleBought(int aID);

    public void DeleteAnnonce(int aID);

    public void BuyAnnonce(int aID, int BuyerId);

}