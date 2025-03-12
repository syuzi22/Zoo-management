using System.ComponentModel.DataAnnotations.Schema;
namespace Zoo_management.DataTransferModels;

public class AddAnimal {
    public string Species {get; set;}
    public string Classification {get; set;} 
    public string Name {get; set;}
    public string Sex {get; set;} 
    public DateOnly DateOfBirth {get;set;}
    public DateOnly DateAcquired {get;set;}    
    public int EnclosureId {get;set;}    
    public int ZooKeeperId {get;set;}    
    public string Status {get;set;}

    public AddAnimal(string species, string classification, string name, string sex, DateOnly dateOfBirth, 
                    DateOnly dateAcquired, string status, int zooKeeperId, int enclosureId) {
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
    public AddAnimal() {}

}