using Estudo1.Interfaces;
using Estudo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estudo1.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController(IAuthRepository au) : Controller
{
    private readonly IAuthRepository _au = au;

    [HttpPost("login")]
    [ProducesResponseType(200, Type = typeof(string))]
    public IActionResult MakeLogin([FromBody] AuthData data)
    // public IActionResult MakeLogin([FromBody] string email, string password)
    {
        var token = _au.MakeLogin(data.Email, data.Password);
        // var token = _au.MakeLogin(email, password);

        return Ok(token);
    }
}