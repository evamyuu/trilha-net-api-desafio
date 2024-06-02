using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrilhaApiDesafio.Migrations
{
    /// <summary>
    /// Represents the migration for creating the CustomTask table.
    /// </summary>
    public partial class CreateCustomTaskTable : Migration
    {
        /// <summary>
        /// Applies the migration to create the CustomTask table.
        /// </summary>
        /// <param name="migrationBuilder">The migration builder.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTasks", x => x.Id);
                });
        }

        /// <summary>
        /// Reverts the migration by dropping the CustomTask table.
        /// </summary>
        /// <param name="migrationBuilder">The migration builder.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomTasks");
        }
    }
}

