using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using TesteMeu.Data;
using TesteMeu.Models;

namespace TesteMeu.Controllers;

[Route("/[controller]")]
[ApiController]
public class PizzasController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pizza>>> GetAllPizzas()
    {
        return AllPizzas.GetAllPizzas();
    }

    [HttpPost]
    public string CreatePizza(Pizza newPizza)
    {
        AllPizzas.AddPizza(newPizza);

        return "Criado";
    }
}
