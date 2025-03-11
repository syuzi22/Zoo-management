using Microsoft.EntityFrameworkCore;
using Zoo_management.Models;

namespace Zoo_management.Database
{
    public class ZooManagementContext : DbContext
    {
        public ZooManagementContext (DbContextOptions<ZooManagementContext> options) : base(options) {}
        public DbSet<Zoo_management.Models.Animal> Animal { get; set; } = default!;
        public DbSet<Zoo_management.Models.Enclosure> Enclosure { get; set; } = default!;
        public DbSet<Zoo_management.Models.Transfer> Transfer { get; set; } = default!;
        public DbSet<Zoo_management.Models.ZooKeeper> ZooKeeper { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enclosure>().HasData(
                new Enclosure("Lion’s Enclosure", 10) { EnclosureId = 1 },
                new Enclosure("Hippo’s Enclosure", 10) { EnclosureId = 2 }
             );

            modelBuilder.Entity<ZooKeeper>().HasData(
                new ZooKeeper("Vani") {ZooKeeperId = 1},
                new ZooKeeper("Siuzanna") {ZooKeeperId = 2}               
            );

            modelBuilder.Entity<Animal>().Property(d => d.Classification)
                        .HasConversion<string>();
            modelBuilder.Entity<Animal>().Property(d => d.Sex)
                        .HasConversion<string>();
            modelBuilder.Entity<Animal>().Property(d => d.Status)
                        .HasConversion<string>();
            modelBuilder.Entity<Animal>().HasData(
                new Animal { AnimalId = 1, Species = "Lion",  Name = "Musafa" , Classification = Classification.Mammal, Sex = Sex.Male, 
                        DateOfBirth = new DateOnly(2020, 3, 15), DateAcquired = new DateOnly(2025, 3, 10), EnclosureId = 1, 
                        ZooKeeperId = 1},
                new Animal { AnimalId = 2, Species = "Hippo",  Name = "Hippolus" , Classification = Classification.Mammal, Sex = Sex.Female, 
                        DateOfBirth = new DateOnly(2017, 3, 15), DateAcquired = new DateOnly(2020, 5, 20), EnclosureId = 2, 
                        ZooKeeperId = 1},
                new Animal("Elephant",Classification.Mammal,"Elm",Sex.Female, new DateOnly(1985,7,12),new DateOnly(1990,7,12),Status.Active,2,1){ AnimalId = 3},
                new Animal("Rhino",Classification.Mammal,"Jack",Sex.Female, new DateOnly(1985,7,12),new DateOnly(1990,7,12),Status.Active,2,1){ AnimalId = 4},
                new Animal("Giraffe",Classification.Mammal,"Tally",Sex.Female, new DateOnly(1985,7,12),new DateOnly(1990,7,12),Status.Active,2,1){ AnimalId = 5},
                new Animal("Ostritch",Classification.Mammal,"Sam",Sex.Female, new DateOnly(1985,7,12),new DateOnly(1990,7,12),Status.Active,2,1){ AnimalId = 6},
                new Animal("Zebra",Classification.Mammal,"Emma",Sex.Female, new DateOnly(1985,7,12),new DateOnly(1990,7,12),Status.Active,2,1){ AnimalId = 7},
                new Animal("Elephant",Classification.Mammal,"Rina",Sex.Female, new DateOnly(1985,7,12),new DateOnly(1990,7,12),Status.Active,1,1){ AnimalId = 8},
                new Animal("Tiger",Classification.Mammal,"Tigerooo",Sex.Female, new DateOnly(1985,7,12),new DateOnly(1990,7,12),Status.Active,2,1){ AnimalId = 9},
                new Animal("Hawk",Classification.Bird,"Prince",Sex.Male, new DateOnly(1985,7,12),new DateOnly(1990,7,12),Status.Active,1,1) { AnimalId = 10}
            );
        }
    }
}