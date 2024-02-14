namespace ContosoPizza.Controllers;
using ContosoPizzaWebAPI.Models;
using ContosoPizzaWebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza == null)
            return NotFound();
        return pizza;
    }

    // POST action

    // PUT action

    // DELETE action
}