using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoo_management.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enclosure",
                columns: table => new
                {
                    EnclosureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MaxNumberOfAnimals = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosure", x => x.EnclosureId);
                });

            migrationBuilder.CreateTable(
                name: "ZooKeeper",
                columns: table => new
                {
                    ZooKeeperId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooKeeper", x => x.ZooKeeperId);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    Classification = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DateAcquired = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EnclosureId = table.Column<int>(type: "INTEGER", nullable: false),
                    ZooKeeperId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animal_Enclosure_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosure",
                        principalColumn: "EnclosureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_ZooKeeper_ZooKeeperId",
                        column: x => x.ZooKeeperId,
                        principalTable: "ZooKeeper",
                        principalColumn: "ZooKeeperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnclosureZooKeeper",
                columns: table => new
                {
                    EnclosuresEnclosureId = table.Column<int>(type: "INTEGER", nullable: false),
                    ZooKeepersZooKeeperId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnclosureZooKeeper", x => new { x.EnclosuresEnclosureId, x.ZooKeepersZooKeeperId });
                    table.ForeignKey(
                        name: "FK_EnclosureZooKeeper_Enclosure_EnclosuresEnclosureId",
                        column: x => x.EnclosuresEnclosureId,
                        principalTable: "Enclosure",
                        principalColumn: "EnclosureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnclosureZooKeeper_ZooKeeper_ZooKeepersZooKeeperId",
                        column: x => x.ZooKeepersZooKeeperId,
                        principalTable: "ZooKeeper",
                        principalColumn: "ZooKeeperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfTransfer = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TransferedZoo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfer_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enclosure",
                columns: new[] { "EnclosureId", "MaxNumberOfAnimals", "Name" },
                values: new object[,]
                {
                    { 1, 10, "Lion’s Enclosure" },
                    { 2, 10, "Hippo’s Enclosure" },
                    { 3, 50, "Aviary" },
                    { 4, 40, "Reptile house" },
                    { 5, 6, "Giraffe enclosure" }
                });

            migrationBuilder.InsertData(
                table: "ZooKeeper",
                columns: new[] { "ZooKeeperId", "Name" },
                values: new object[,]
                {
                    { 1, "Vani" },
                    { 2, "Siuzanna" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalId", "Classification", "DateAcquired", "DateOfBirth", "EnclosureId", "Name", "Sex", "Species", "Status", "ZooKeeperId" },
                values: new object[,]
                {
                    { 1, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 0", "Male", "Lion", "Active", 1 },
                    { 2, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 1", "Female", "Hippo", "Active", 1 },
                    { 3, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 2", "Male", "Elephant", "Active", 1 },
                    { 4, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 3", "Female", "Rhino", "Active", 1 },
                    { 5, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 4", "Male", "Giraffe", "Active", 1 },
                    { 6, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 5", "Female", "Ostritch", "Active", 1 },
                    { 7, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 6", "Male", "Zebra", "Active", 1 },
                    { 8, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 7", "Female", "Tiger", "Active", 1 },
                    { 9, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 8", "Male", "Hawk", "Active", 1 },
                    { 10, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 9", "Female", "Lion", "Active", 1 },
                    { 11, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 10", "Male", "Hippo", "Active", 1 },
                    { 12, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 11", "Female", "Elephant", "Active", 1 },
                    { 13, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 12", "Male", "Rhino", "Active", 1 },
                    { 14, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 13", "Female", "Giraffe", "Active", 1 },
                    { 15, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 14", "Male", "Ostritch", "Active", 1 },
                    { 16, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 15", "Female", "Zebra", "Active", 1 },
                    { 17, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 16", "Male", "Tiger", "Active", 1 },
                    { 18, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 17", "Female", "Hawk", "Active", 1 },
                    { 19, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 18", "Male", "Lion", "Active", 1 },
                    { 20, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 19", "Female", "Hippo", "Active", 1 },
                    { 21, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 20", "Male", "Elephant", "Active", 1 },
                    { 22, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 21", "Female", "Rhino", "Active", 1 },
                    { 23, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 22", "Male", "Giraffe", "Active", 1 },
                    { 24, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 23", "Female", "Ostritch", "Active", 1 },
                    { 25, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 24", "Male", "Zebra", "Active", 1 },
                    { 26, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 25", "Female", "Tiger", "Active", 1 },
                    { 27, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 26", "Male", "Hawk", "Active", 1 },
                    { 28, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 27", "Female", "Lion", "Active", 1 },
                    { 29, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 28", "Male", "Hippo", "Active", 1 },
                    { 30, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 29", "Female", "Elephant", "Active", 1 },
                    { 31, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 30", "Male", "Rhino", "Active", 1 },
                    { 32, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 31", "Female", "Giraffe", "Active", 1 },
                    { 33, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 32", "Male", "Ostritch", "Active", 1 },
                    { 34, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 33", "Female", "Zebra", "Active", 1 },
                    { 35, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 34", "Male", "Tiger", "Active", 1 },
                    { 36, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 35", "Female", "Hawk", "Active", 1 },
                    { 37, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 36", "Male", "Lion", "Active", 1 },
                    { 38, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 37", "Female", "Hippo", "Active", 1 },
                    { 39, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 38", "Male", "Elephant", "Active", 1 },
                    { 40, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 39", "Female", "Rhino", "Active", 1 },
                    { 41, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 40", "Male", "Giraffe", "Active", 1 },
                    { 42, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 41", "Female", "Ostritch", "Active", 1 },
                    { 43, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 42", "Male", "Zebra", "Active", 1 },
                    { 44, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 43", "Female", "Tiger", "Active", 1 },
                    { 45, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 44", "Male", "Hawk", "Active", 1 },
                    { 46, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 45", "Female", "Lion", "Active", 1 },
                    { 47, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 46", "Male", "Hippo", "Active", 1 },
                    { 48, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 47", "Female", "Elephant", "Active", 1 },
                    { 49, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 48", "Male", "Rhino", "Active", 1 },
                    { 50, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 49", "Female", "Giraffe", "Active", 1 },
                    { 51, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 50", "Male", "Ostritch", "Active", 1 },
                    { 52, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 51", "Female", "Zebra", "Active", 1 },
                    { 53, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 52", "Male", "Tiger", "Active", 1 },
                    { 54, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 53", "Female", "Hawk", "Active", 1 },
                    { 55, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 54", "Male", "Lion", "Active", 1 },
                    { 56, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 55", "Female", "Hippo", "Active", 1 },
                    { 57, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 56", "Male", "Elephant", "Active", 1 },
                    { 58, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 57", "Female", "Rhino", "Active", 1 },
                    { 59, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 58", "Male", "Giraffe", "Active", 1 },
                    { 60, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 59", "Female", "Ostritch", "Active", 1 },
                    { 61, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 60", "Male", "Zebra", "Active", 1 },
                    { 62, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 61", "Female", "Tiger", "Active", 1 },
                    { 63, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 62", "Male", "Hawk", "Active", 1 },
                    { 64, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 63", "Female", "Lion", "Active", 1 },
                    { 65, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 64", "Male", "Hippo", "Active", 1 },
                    { 66, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 65", "Female", "Elephant", "Active", 1 },
                    { 67, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 66", "Male", "Rhino", "Active", 1 },
                    { 68, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 67", "Female", "Giraffe", "Active", 1 },
                    { 69, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 68", "Male", "Ostritch", "Active", 1 },
                    { 70, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 69", "Female", "Zebra", "Active", 1 },
                    { 71, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 70", "Male", "Tiger", "Active", 1 },
                    { 72, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 71", "Female", "Hawk", "Active", 1 },
                    { 73, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 72", "Male", "Lion", "Active", 1 },
                    { 74, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 73", "Female", "Hippo", "Active", 1 },
                    { 75, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 74", "Male", "Elephant", "Active", 1 },
                    { 76, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 75", "Female", "Rhino", "Active", 1 },
                    { 77, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 76", "Male", "Giraffe", "Active", 1 },
                    { 78, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 77", "Female", "Ostritch", "Active", 1 },
                    { 79, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 78", "Male", "Zebra", "Active", 1 },
                    { 80, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 79", "Female", "Tiger", "Active", 1 },
                    { 81, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 80", "Male", "Hawk", "Active", 1 },
                    { 82, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 81", "Female", "Lion", "Active", 1 },
                    { 83, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 82", "Male", "Hippo", "Active", 1 },
                    { 84, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 83", "Female", "Elephant", "Active", 1 },
                    { 85, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 84", "Male", "Rhino", "Active", 1 },
                    { 86, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 85", "Female", "Giraffe", "Active", 1 },
                    { 87, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 86", "Male", "Ostritch", "Active", 1 },
                    { 88, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 87", "Female", "Zebra", "Active", 1 },
                    { 89, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 88", "Male", "Tiger", "Active", 1 },
                    { 90, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 89", "Female", "Hawk", "Active", 1 },
                    { 91, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 90", "Male", "Lion", "Active", 1 },
                    { 92, "Invertebrate", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 91", "Female", "Hippo", "Active", 1 },
                    { 93, "Mammal", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 92", "Male", "Elephant", "Active", 1 },
                    { 94, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 93", "Female", "Rhino", "Active", 1 },
                    { 95, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 94", "Male", "Giraffe", "Active", 1 },
                    { 96, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 95", "Female", "Ostritch", "Active", 1 },
                    { 97, "Fish", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 3, "Animalname 96", "Male", "Zebra", "Active", 1 },
                    { 98, "Insect", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 4, "Animalname 97", "Female", "Tiger", "Active", 1 },
                    { 99, "Bird", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 2, "Animalname 98", "Male", "Hawk", "Active", 1 },
                    { 100, "Reptile", new DateOnly(2022, 7, 25), new DateOnly(2018, 7, 15), 1, "Animalname 99", "Female", "Lion", "Active", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_EnclosureId",
                table: "Animal",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ZooKeeperId",
                table: "Animal",
                column: "ZooKeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_EnclosureZooKeeper_ZooKeepersZooKeeperId",
                table: "EnclosureZooKeeper",
                column: "ZooKeepersZooKeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_AnimalId",
                table: "Transfer",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnclosureZooKeeper");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Enclosure");

            migrationBuilder.DropTable(
                name: "ZooKeeper");
        }
    }
}
