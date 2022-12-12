using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tdAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumToDos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingsId);
                });

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    ToDoListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.ToDoListId);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    DueBy = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Importance = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.ToDoId);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "SettingsId", "NumToDos" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                column: "ToDoListId",
                value: 1);

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ToDoId", "CreatedTime", "DueBy", "Importance", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 12, 13, 0, 58, 953, DateTimeKind.Utc).AddTicks(4680), new DateTime(2022, 12, 12, 13, 0, 58, 953, DateTimeKind.Utc).AddTicks(4680), 1, "First todo" },
                    { 2, new DateTime(2022, 12, 12, 13, 0, 58, 953, DateTimeKind.Utc).AddTicks(4680), new DateTime(2022, 12, 12, 13, 0, 58, 953, DateTimeKind.Utc).AddTicks(4680), 9, "Second todo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
