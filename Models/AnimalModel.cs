using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Zoo_management.DataTransferModels;
using Zoo_management.enums;
namespace Zoo_management.Models;

public class Animal {
    public int AnimalId {get; set;}
    public string Species {get; set;}
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Classification Classification {get; set;} 
    public string Name {get; set;}
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Sex Sex {get; set;} 
    public DateOnly DateOfBirth {get;set;}
    public DateOnly DateAcquired {get;set;}    
    public int EnclosureId {get;set;}
    public Enclosure Enclosure {get;set;} 
    public int ZooKeeperId {get;set;}
    public ZooKeeper ZooKeeper {get;set;} 
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status {get;set;}

    public Animal(string species, Classification classification, string name, Sex sex, DateOnly dateOfBirth, 
                    DateOnly dateAcquired, Status status, int zooKeeperId, int enclosureId) {
        Species = species;
        Classification = classification;
        Name = name;
        Sex = sex;
        DateOfBirth = dateOfBirth;
        DateAcquired = dateAcquired;
        Status = status;
        ZooKeeperId = zooKeeperId;
        EnclosureId = enclosureId;
    }
    public Animal() {}

    public Animal(AddAnimal addAnimal) {
        Species = addAnimal.Species;
        Classification = (Classification)Enum.Parse(typeof(Classification),addAnimal.Classification);
        Name = addAnimal.Name;
        Sex = (Sex)Enum.Parse(typeof(Sex),addAnimal.Sex);
        DateOfBirth = addAnimal.DateOfBirth;
        DateAcquired = addAnimal.DateAcquired;
        Status = (Status)Enum.Parse(typeof(Status),addAnimal.Status);
        ZooKeeperId = addAnimal.ZooKeeperId;
        EnclosureId = addAnimal.EnclosureId;
    }
}