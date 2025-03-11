using Microsoft.AspNetCore.Mvc;
using Zoo_management.Models;
using Zoo_management.Database;
namespace Zoo_management.Controllers;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase {

    private readonly ZooManagementContext _context;

    public AnimalController(ZooManagementContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetAnimalDetails")]
    public async Task<Animal> Get(int animalId)
    {
        return await _context.Animal
            .Include(animal => animal.Enclosure)
            .Include(animal => animal.ZooKeeper)
            .FirstOrDefaultAsync(a => a.AnimalId == animalId);
 
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Animal animal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Animal newAnimal = new Animal(animal.Species, animal.Classification, animal.Name,
                 animal.Sex, animal.DateOfBirth, animal.DateAcquired, animal.Status, animal.ZooKeeperId, animal.EnclosureId);
        _context.Animal.Add(newAnimal);
        int animalId = await _context.SaveChangesAsync();
     
        return CreatedAtAction("GetAnimalDetails", animalId);
    }
}
    
