using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace Backend.Controllers;

[ApiController]
[Route("api/Annonce")]
public class AnnonceController : ControllerBase
{
    private IAnnonceRepo aRepo;

    public AnnonceController(IAnnonceRepo repo)
    {
        aRepo = repo;
    }

    [HttpPost]
    [Route("create")]
    public void AddAnnonce(Annonce newAnnonce)
    {
        newAnnonce.aID = aRepo.GetNextId();
        //Den nye annonces ID skal benytte det seneste ID der er tilgængeligt i databasen.
        //getlatestid er altså en funktion i repo, ikke her.
        //TODO lav getlatestid
        aRepo.AddAnnonce(newAnnonce); //Add er også repo funktion
    }

    [HttpGet]
    [Route("get")]
    public List<Annonce> GetAllAnnonces()
    {
        return aRepo.GetAllAnnonces(); //kalder GetAll fra Repo
    }

    [HttpGet]
    [Route("sold/{userId:int}")] //alle solgte annoncer for en bruger
    public List<Annonce> GetSoldAnnonces(int userId)
    {
        return aRepo.GetSoldAnnonces(userId);
    }
/*
    [HttpPatch]
    [Route("toggle/{aID:int}")] //Får et annonce ID, som er integer, som defineret i klassen
    public void PutToggleBought(int aID)
    {
        aRepo.PutToggleBought(aID); //kald toggle på repo
    }
*/
    [HttpDelete]
    [Route("delete/{aID:int}")] //samme som ovenfor
    public void DeleteAnnonce(int aID)
    {
        aRepo.DeleteAnnonce(aID);
    }

    [HttpPatch]
    [Route("buy/{aID:int}")]
    public void BuyAnnonce(int aID, int BuyerId)
    {
        aRepo.BuyAnnonce(aID, BuyerId);
    }
    
    
}
