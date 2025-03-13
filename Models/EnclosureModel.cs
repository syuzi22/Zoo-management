using System.Text.Json.Serialization;

namespace Zoo_management.Models;

public class Enclosure {
    public int EnclosureId {get; set;}
    public string Name {get; set;}   
    [JsonIgnore]
    public List<ZooKeeper>? ZooKeepers {get; set;}
    [JsonIgnore]
    public List<Animal>? Animals {get; set;}
    public int MaxNumberOfAnimals {get; set;}

    public Enclosure(string name, int maxNumberOfAnimals) {
        Name = name;
        MaxNumberOfAnimals = maxNumberOfAnimals;
    }

    public Enclosure() {}
}