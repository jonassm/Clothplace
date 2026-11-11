using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace Backend.Controllers;

[ApiController]
[Route("api/Purchases")]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseRepo pRepo;
    
    [HttpGet]
    [Route("getCar")]
    public List<Purchase> getPurchaseByBuyerId(int id)
    {
        return pRepo.getPurchaseByBuyerId(id);
    }
}