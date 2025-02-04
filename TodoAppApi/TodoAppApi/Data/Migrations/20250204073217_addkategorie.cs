using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoAppApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class addkategorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kategorie",
                table: "todo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategorie",
                table: "todo");
        }
    }
}
