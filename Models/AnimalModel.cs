using System.ComponentModel.DataAnnotations.Schema;

namespace Zoo_management.Models;

public enum Sex {
    Male,
    Female
}

public enum Classification {
    Mammal,
    Reptile,
    Bird,
    Insect,
    Fish,
    Invertebrate
}

public enum Status {
    Active,
    Transfered,
    Dead
}

public class Animal {
    public int AnimalId {get; set;}
    public string Species {get; set;}
    public Classification Classification {get; set;} 
    public string Name {get; set;}
    public Sex Sex {get; set;} 
    public DateOnly DateOfBirth {get;set;}
    public DateOnly DateAcquired {get;set;}    
    public int EnclosureId {get;set;}
    public Enclosure Enclosure {get;set;} 
    public int ZooKeeperId {get;set;}
    public ZooKeeper ZooKeeper {get;set;} 
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
}