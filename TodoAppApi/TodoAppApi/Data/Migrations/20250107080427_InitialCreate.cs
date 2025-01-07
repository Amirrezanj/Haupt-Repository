using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoAppApi.Data.Migrations
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
                    country = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "todo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    dueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todo", x => x.id);
                    table.ForeignKey(
                        name: "FK_todo_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_todo_UserId",
                table: "todo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_AddressId",
                table: "users",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todo");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
