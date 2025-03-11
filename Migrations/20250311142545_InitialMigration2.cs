using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo_management.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Animal",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Animal",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Classification",
                table: "Animal",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Mammal", "Male", "Active" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 2,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Mammal", "Female", "Active" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 3,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Mammal", "Female", "Active" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 4,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Mammal", "Female", "Active" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 5,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Mammal", "Female", "Active" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 6,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Mammal", "Female", "Active" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 7,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Mammal", "Female", "Active" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 8,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Mammal", "Female", "Active" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 9,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Mammal", "Female", "Active" });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 10,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { "Bird", "Male", "Active" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Sex",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Classification",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 2,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 0, 1, 0 });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 3,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 0, 1, 0 });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 4,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 0, 1, 0 });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 5,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 0, 1, 0 });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 6,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 0, 1, 0 });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 7,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 0, 1, 0 });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 8,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 0, 1, 0 });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 9,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 0, 1, 0 });

            migrationBuilder.UpdateData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: 10,
                columns: new[] { "Classification", "Sex", "Status" },
                values: new object[] { 2, 0, 0 });
        }
    }
}
