using Microsoft.AspNetCore.Mvc;
using Zoo_management.Models;
using Zoo_management.Database;
namespace Zoo_management.Controllers;
using Microsoft.EntityFrameworkCore;
using Zoo_management.DataTransferModels;
using Utility;
using Zoo_management.enums;

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
    public async Task<IActionResult> Post([FromBody] AddAnimal addAnimal)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if(!Utility.InputValidations.ValidateClassification(addAnimal.Classification)) {
             return BadRequest("Invalid Animal Classification. Allowed values are " + 
                    String.Join(",", Enum.GetValues(typeof(Classification)).Cast<Classification>()));
        }
        if(!Utility.InputValidations.ValidateSex(addAnimal.Sex)) {
             return BadRequest("Invalid Animal Sex. Allowed values are " + 
                    String.Join(",", Enum.GetValues(typeof(Sex)).Cast<Sex>()));
        }
        if(!Utility.InputValidations.ValidateStatus(addAnimal.Status)) {
             return BadRequest("Invalid Animal Status. Allowed values are " + 
                    String.Join(",", Enum.GetValues(typeof(Status)).Cast<Status>()));
        }
        Animal animal = new Animal(addAnimal);
        _context.Animal.Add(animal);
        int animalId = await _context.SaveChangesAsync();

        animal = await _context.Animal
            .Include(animal => animal.Enclosure)
            .Include(animal => animal.ZooKeeper)
            .FirstOrDefaultAsync(a => a.AnimalId == animalId);
           
        return CreatedAtRoute("GetAnimalDetails", new { id = animalId }, animal);
    }
}
    
