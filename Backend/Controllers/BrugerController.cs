using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace Backend.Controllers;

[ApiController]
[Route("api/Bruger")]
public class BrugerController : ControllerBase
{
    private readonly IBrugerRepo bRepo;

    [HttpGet]
    [Route("getUser")]
    public User getUserById(int id)
    {
        return bRepo.getUserById(id);
    }

    /**
    [HttpGet]
    [Route("getPassword")]
    public string getPasswordByName()
    {
        
    }
    **/
}