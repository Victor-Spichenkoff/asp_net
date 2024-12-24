using System.Security.Claims;
using Estudo1.Helpers;
using Estudo1.Interfaces;
using Estudo1.Models;
using Estudo1.Repositories;
using Estudo1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estudo1.Controllers;

[ApiController]
[Route("/user")]
public class UserController(IUserRepository ur, IEmailService es) : ControllerBase
//novo tipo
{
    private readonly IUserRepository _ur = ur;
    private readonly IEmailService _es = es;

    [HttpGet]
    // [Authorize]//precisa do token bearer na request
    // [Authorize(Roles = "admin,owner")]//multiplos e filtros diferentes 
    [ProducesResponseType(200, Type = typeof(List<User>))]
    public IActionResult GetAll()
    {
        return Ok(_ur.GetAllUsers());
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(200, Type = typeof(User))]
    [ProducesResponseType(404)]
    public IActionResult GetById(int id)
    {
        if (id < 1)
            throw new GenericApiError("ID negativo?", 400);

        var user = _ur.GetUserById(id);

        return Ok(user);
    }

    [HttpGet("/email")]
    public string SendEmail()
    {
        return _es.MandarEmail("victor@gmail.com", "Teste", "doshf fdj dsf sfd ");
    }


    [HttpPost]
    public string CreateUser([FromBody] User user)
    {
        if(user == null)
            throw new GenericApiError("Deve passar um usuário", 400);

        if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Name))
            throw new GenericApiError("Preencha todos os campos", 400);

        if (_ur.USerExist(user.Email))
            throw new GenericApiError("Email já usado", 400);
            
        var success = _ur.AddUser(user);

        if (!success)
            throw new GenericApiError("Erro interno", 500);

        return user.Email;
    }

    [HttpGet("safe")]
    [Authorize]
    [ProducesResponseType(200, Type = typeof(string))]
    public IActionResult GetSafeEmail()
    {
        var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var id = User.Identity?.Name;
        
        return Ok("Logado: " + email + " - " + id);
    }
}