namespace Zoo_management.Models;

public class Enclosure {
    public int EnclosureId {get; set;}
    public string Name {get; set;}   
    public List<ZooKeeper>? ZooKeepers {get; set;}
    public List<Animal>? Animals {get; set;}
    public int MaxNumberOfAnimals {get; set;}

    public Enclosure(string name, int maxNumberOfAnimals) {
        Name = name;
        MaxNumberOfAnimals = maxNumberOfAnimals;
    }

    public Enclosure() {}
}