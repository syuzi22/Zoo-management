using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoo_management.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    Classification = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DateAcquired = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EnclosureId = table.Column<int>(type: "INTEGER", nullable: false),
                    ZooKeeperId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
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
                    { 2, 10, "Hippo’s Enclosure" }
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
                    { 1, 0, new DateOnly(2025, 3, 10), new DateOnly(2020, 3, 15), 1, "Musafa", 0, "Lion", 0, 1 },
                    { 2, 0, new DateOnly(2020, 5, 20), new DateOnly(2017, 3, 15), 2, "Hippolus", 1, "Hippo", 0, 1 },
                    { 3, 0, new DateOnly(1990, 7, 12), new DateOnly(1985, 7, 12), 1, "Elm", 1, "Elephant", 0, 2 },
                    { 4, 0, new DateOnly(1990, 7, 12), new DateOnly(1985, 7, 12), 1, "Jack", 1, "Rhino", 0, 2 },
                    { 5, 0, new DateOnly(1990, 7, 12), new DateOnly(1985, 7, 12), 1, "Tally", 1, "Giraffe", 0, 2 },
                    { 6, 0, new DateOnly(1990, 7, 12), new DateOnly(1985, 7, 12), 1, "Sam", 1, "Ostritch", 0, 2 },
                    { 7, 0, new DateOnly(1990, 7, 12), new DateOnly(1985, 7, 12), 1, "Emma", 1, "Zebra", 0, 2 },
                    { 8, 0, new DateOnly(1990, 7, 12), new DateOnly(1985, 7, 12), 1, "Rina", 1, "Elephant", 0, 1 },
                    { 9, 0, new DateOnly(1990, 7, 12), new DateOnly(1985, 7, 12), 1, "Tigerooo", 1, "Tiger", 0, 2 },
                    { 10, 2, new DateOnly(1990, 7, 12), new DateOnly(1985, 7, 12), 1, "Prince", 0, "Hawk", 0, 1 }
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
