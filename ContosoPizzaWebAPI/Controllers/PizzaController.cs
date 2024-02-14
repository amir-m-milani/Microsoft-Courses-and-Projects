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
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        // The pizza was added to the in-memory cache.
        // The pizza is included in the response body in the media type,
        // as defined in the accept HTTP request header (JSON by default).
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        // check if the id is correct
        if (id != pizza.Id)
            return BadRequest();
        // get the pizza
        var existingPizaa = PizzaService.Get(id);
        // check if the pizza in the database
        if (existingPizaa == null)
            return NotFound();
        // if yse => Update the pizza
        PizzaService.Update(pizza);
        // return the result 
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // get the pizza from database
        var pizza = PizzaService.Get(id);
        // check pizza exists
        if (pizza == null)
            return NotFound();
        // delete the pizza if found
        PizzaService.Delete(id);
        return NoContent();
    }
}