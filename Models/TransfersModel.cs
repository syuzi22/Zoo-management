namespace Zoo_management.Models;

public class Transfer {
    public int Id {get; set;}
    public int AnimalId {get;set;}
    public Animal Animal {get; set;}
    public DateOnly DateOfTransfer {get;set;}
    public string? TransferedZoo {get;set;}

    public Transfer(int animalId, DateOnly dateOfTransfer, string transferedZoo) {
        AnimalId = animalId;
        DateOfTransfer = dateOfTransfer;
        TransferedZoo = transferedZoo;
    }

    public Transfer() {}
}