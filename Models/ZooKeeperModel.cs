namespace Zoo_management.Models;

public class ZooKeeper {
    public int ZooKeeperId {get; set;}
    public List<Enclosure> Enclosures {get; set;}
    public List<Animal> Animals {get; set;}
    public string Name {get; set;}   

    public ZooKeeper(string name) {
        Name = name;
    }

    public ZooKeeper() {}
}
