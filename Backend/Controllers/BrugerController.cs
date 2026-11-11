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
    [Route("getUser/{id}")]
    public User getUser(int id)
    {
        return bRepo.getUser(id);
    }

    [HttpPost]
    [Route("doLogin/{email}")]
    public User Login(string email)
    {
        return bRepo.Login(email);
    }

    [HttpPost]
    [Route("createUser")]
    public void CreateUser([FromBody] User user)
    //Vi får jo brugeren fra body, da en bruger laver brugeren ude i frontenden, som så bliver sendt som JSON.
    //Heraf "from body"
    {
        bRepo.CreateUser(user);
    }

    /**
    [HttpGet]
    [Route("getPassword")]
    public string getPasswordByName()
    {
        
    }
    **/
}