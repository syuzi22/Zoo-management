using Microsoft.AspNetCore.Mvc;
using Zoo_management.Models;
using Zoo_management.Database;
namespace Zoo_management.Controllers;
using Microsoft.EntityFrameworkCore;
using Zoo_management.DataTransferModels;
using Zoo_management.enums;
using NLog;
using Zoo_management.Logger;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase {

    private readonly ZooManagementContext _context;
    
    private readonly ILogger<AnimalController> _logger;

    public AnimalController(ZooManagementContext context, ILogger<AnimalController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("GetDetails")]
    public async Task<Animal> Get(int animalId)
    {
        _logger.LogInformation("Inside GetAnimalDetails");
        return await _context.Animal
            .Include(animal => animal.Enclosure)
            .Include(animal => animal.ZooKeeper)
            .FirstOrDefaultAsync(a => a.AnimalId == animalId);
 
    }

    [HttpGet("GetAll")]
    public async Task<List<Animal>> GetAll()
    {
        _logger.LogInformation("Inside GetAllAnimals");
        return await _context.Animal
            .Include(animal => animal.Enclosure)
            .Include(animal => animal.ZooKeeper).ToListAsync(); 
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddAnimal addAnimal)
    {
         _logger.LogInformation("Inside Add an animal");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if(!Utility.InputValidations.ValidateClassification(addAnimal.Classification)) {
            _logger.LogError("Invalid Animal Classification. Allowed values are " + 
                    String.Join(",", Enum.GetValues(typeof(Classification)).Cast<Classification>()));
             return BadRequest("Invalid Animal Classification. Allowed values are " + 
                    String.Join(",", Enum.GetValues(typeof(Classification)).Cast<Classification>()));
        }
        if(!Utility.InputValidations.ValidateSex(addAnimal.Sex)) {
             _logger.LogError("Invalid Animal Sex. Allowed values are " + 
                    String.Join(",", Enum.GetValues(typeof(Sex)).Cast<Sex>()));
             return BadRequest("Invalid Animal Sex. Allowed values are " + 
                    String.Join(",", Enum.GetValues(typeof(Sex)).Cast<Sex>()));
        }
        if(!Utility.InputValidations.ValidateStatus(addAnimal.Status)) {
             _logger.LogError("Invalid Animal Status. Allowed values are " + 
                    String.Join(",", Enum.GetValues(typeof(Status)).Cast<Status>()));
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
    
