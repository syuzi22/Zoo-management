using Microsoft.EntityFrameworkCore;
using Zoo_management.Models;
using Zoo_management.enums;

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
                new Enclosure("Hippo’s Enclosure", 10) { EnclosureId = 2 },
                new Enclosure("Aviary", 50) { EnclosureId = 3 },
                new Enclosure("Reptile house", 40) { EnclosureId = 4 },
                new Enclosure("Giraffe enclosure", 6) { EnclosureId = 5 }
             );

            modelBuilder.Entity<ZooKeeper>().HasData(
                new ZooKeeper("Vani") {ZooKeeperId = 1},
                new ZooKeeper("Siuzanna") {ZooKeeperId = 2}             
            );

            Animal[] randomAnimals = new Animal[100];
            string[] speciesList = ["Lion", "Hippo", "Elephant", "Rhino", "Giraffe", "Ostritch", "Zebra", "Tiger", "Hawk"];
            var classificationValues = Enum.GetValues(typeof(Classification)).Cast<Classification>().ToArray();
            var random = new Random();

            for (int i = 0; i < randomAnimals.Length; i++) {
                string species = speciesList[i % speciesList.Length];
                Classification randomClassification = (Classification)Enum.Parse(typeof(Classification), Enum.GetValues(typeof(Classification))
                                      .Cast<Classification>()
                                      .ElementAt(random.Next(classificationValues.Length))
                                      .ToString());

                Sex sex = (Sex)Enum.Parse(typeof(Sex), Enum.GetValues(typeof(Sex))
                                      .Cast<Sex>()
                                      .ElementAt(i%2)
                                      .ToString());

                DateOnly DateOfBirth = new DateOnly(2018,7, 15);
                DateOnly DateAcquired = new DateOnly(2022,7, 25);

                randomAnimals[i] = new Animal(
                    species,
                    randomClassification,
                    $"Animalname {i}",
                    sex,
                    DateOfBirth,
                    DateAcquired,
                    Status.Active,
                    random.Next(1, 2),
                    random.Next(1, 5)
                ){ AnimalId = i + 1};
            }
            
            modelBuilder.Entity<Animal>().Property(a => a.Classification)
                        .HasConversion(
                            v => v.ToString(),
                            v => (Classification)Enum.Parse(typeof(Classification), v) 
                        );
            modelBuilder.Entity<Animal>().Property(a => a.Sex)
                        .HasConversion(
                            v => v.ToString(),
                            v => (Sex)Enum.Parse(typeof(Sex), v) 
                        );
            modelBuilder.Entity<Animal>().Property(a => a.Status)
                        .HasConversion(
                            v => v.ToString(),
                            v => (Status)Enum.Parse(typeof(Status), v) 
                        );
            modelBuilder.Entity<Animal>().HasData(randomAnimals);
        }
    }
}