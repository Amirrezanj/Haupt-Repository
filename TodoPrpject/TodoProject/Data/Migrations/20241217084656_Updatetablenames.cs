using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatetablenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_users_UserId",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "todo");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "todo",
                newName: "dueDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "todo",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "todo",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_UserId",
                table: "todo",
                newName: "IX_todo_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_todo",
                table: "todo",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_todo_users_UserId",
                table: "todo",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todo_users_UserId",
                table: "todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_todo",
                table: "todo");

            migrationBuilder.RenameTable(
                name: "todo",
                newName: "Todos");

            migrationBuilder.RenameColumn(
                name: "dueDate",
                table: "Todos",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Todos",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Todos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_todo_UserId",
                table: "Todos",
                newName: "IX_Todos_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_users_UserId",
                table: "Todos",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
