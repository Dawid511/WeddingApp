using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ToDoListAddedToWedding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_WeddingId",
                table: "ToDoLists");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_WeddingId",
                table: "ToDoLists",
                column: "WeddingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_WeddingId",
                table: "ToDoLists");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_WeddingId",
                table: "ToDoLists",
                column: "WeddingId");
        }
    }
}
