using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", maxLength: 60, nullable: false),
                    street = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    houseNumber = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    zipCode = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    country = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    firstNumber = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    secondName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    lastName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    AddressId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_AddressId",
                table: "users",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
