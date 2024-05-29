using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreweryMaster.API.Migrations.User
{
    /// <inheritdoc />
    public partial class FixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Empoyees",
                table: "Empoyees");

            migrationBuilder.RenameTable(
                name: "Empoyees",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Empoyees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empoyees",
                table: "Empoyees",
                column: "ID");
        }
    }
}
