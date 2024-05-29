using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreweryMaster.API.Migrations.WorkDb
{
    /// <inheritdoc />
    public partial class AddStatusFiledToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "KanbanTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "KanbanTasks");
        }
    }
}
