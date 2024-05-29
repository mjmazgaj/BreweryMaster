using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreweryMaster.API.Migrations.WorkDb
{
    /// <inheritdoc />
    public partial class UpdateKanbanTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "KanbanTasks");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "KanbanTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KanbanTasks",
                table: "KanbanTasks",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KanbanTasks",
                table: "KanbanTasks");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "KanbanTasks");

            migrationBuilder.RenameTable(
                name: "KanbanTasks",
                newName: "Tasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "ID");
        }
    }
}
