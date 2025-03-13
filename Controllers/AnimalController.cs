using Microsoft.AspNetCore.Mvc;
using Zoo_management.Models;
using Zoo_management.Database;
namespace Zoo_management.Controllers;
using Microsoft.EntityFrameworkCore;
using Zoo_management.DataTransferModels;
using Zoo_management.enums;
using NLog;
using System.Reflection;

public class Parameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Species { get; set; }
    public Classification? Classification {get;set;}
    public string? Name {get;set;}
    public string? Age {get;set;}
    public DateOnly? DateAcquired {get;set;}
    public string? OrderBy {get;set;}
}

[ApiController]
[Route("[controller]")]
public class 
AnimalController : ControllerBase {

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

    [HttpGet("GetPaginated")]
    public async Task<List<Animal>> GetPaginated([FromQuery] Parameters parameters)
    {
        _logger.LogInformation("Inside GetPaginated");  

        var animalsQuery = _context.Animal
            .Include(animal => animal.Enclosure)
            .Include(animal => animal.ZooKeeper)
            .Where(animal => parameters.Species == null || animal.Species == parameters.Species)
            .Where(animal => parameters.Classification == null || animal.Classification == parameters.Classification)
            .Where(animal => parameters.Age == null ||  (DateTime.Today.Year - animal.DateOfBirth.Year) == Int32.Parse(parameters.Age))
            .Where(animal => parameters.Name == null || animal.Name == parameters.Name)
            .Where(animal => parameters.DateAcquired == null || animal.DateAcquired == parameters.DateAcquired)
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize);
            // .OrderBy(animal => typeof(Animal).GetField(parameters.OrderBy))
            // .ToListAsync();

            if(!String.IsNullOrEmpty(parameters.OrderBy)) {
                if(parameters.OrderBy.Equals("Age")) {
                    return await animalsQuery.OrderBy(animal => animal.DateOfBirth).ToListAsync();
                }
                if(parameters.OrderBy.Equals("Name")) {
                    return await animalsQuery.OrderBy(animal => animal.Name).ToListAsync();
                }
                if(parameters.OrderBy.Equals("Sex")) {
                    return await animalsQuery.OrderBy(animal => animal.Sex).ToListAsync();
                }
                if(parameters.OrderBy.Equals("Classification")) {
                    return await animalsQuery.OrderBy(animal => animal.Classification).ToListAsync();
                }
                if(parameters.OrderBy.Equals("DateAcquired")) {
                    return await animalsQuery.OrderBy(animal => animal.DateAcquired).ToListAsync();
                }
                if(parameters.OrderBy.Equals("Status")) {
                    return await animalsQuery.OrderBy(animal => animal.Status).ToListAsync();
                }
            }
           
        return await animalsQuery.OrderBy(animal => animal.Species).ToListAsync();
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
    
