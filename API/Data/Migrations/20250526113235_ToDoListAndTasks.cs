using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ToDoListAndTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseItem_ExpenseList_ExpenseListId",
                table: "ExpenseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseList_Weddings_WeddingId",
                table: "ExpenseList");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_GuestList_GuestListId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestList_Weddings_WeddingId",
                table: "GuestList");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Vendors_VendorId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestList",
                table: "GuestList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "Guest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseList",
                table: "ExpenseList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseItem",
                table: "ExpenseItem");

            migrationBuilder.RenameTable(
                name: "GuestList",
                newName: "GuestLists");

            migrationBuilder.RenameTable(
                name: "Guest",
                newName: "Guests");

            migrationBuilder.RenameTable(
                name: "ExpenseList",
                newName: "ExpenseLists");

            migrationBuilder.RenameTable(
                name: "ExpenseItem",
                newName: "ExpenseItems");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "Photos",
                newName: "VendorID");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_VendorId",
                table: "Photos",
                newName: "IX_Photos_VendorID");

            migrationBuilder.RenameIndex(
                name: "IX_GuestList_WeddingId",
                table: "GuestLists",
                newName: "IX_GuestLists_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Guest_GuestListId",
                table: "Guests",
                newName: "IX_Guests_GuestListId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseList_WeddingId",
                table: "ExpenseLists",
                newName: "IX_ExpenseLists_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseItem_ExpenseListId",
                table: "ExpenseItems",
                newName: "IX_ExpenseItems_ExpenseListId");

            migrationBuilder.AlterColumn<int>(
                name: "VendorID",
                table: "Photos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestLists",
                table: "GuestLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseLists",
                table: "ExpenseLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseItems",
                table: "ExpenseItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeddingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoLists_Weddings_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Weddings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ToDoListId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoTasks_ToDoLists_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "ToDoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_WeddingId",
                table: "ToDoLists",
                column: "WeddingId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTasks_ToDoListId",
                table: "ToDoTasks",
                column: "ToDoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseItems_ExpenseLists_ExpenseListId",
                table: "ExpenseItems",
                column: "ExpenseListId",
                principalTable: "ExpenseLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseLists_Weddings_WeddingId",
                table: "ExpenseLists",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestLists_Weddings_WeddingId",
                table: "GuestLists",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_GuestLists_GuestListId",
                table: "Guests",
                column: "GuestListId",
                principalTable: "GuestLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Vendors_VendorID",
                table: "Photos",
                column: "VendorID",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseItems_ExpenseLists_ExpenseListId",
                table: "ExpenseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseLists_Weddings_WeddingId",
                table: "ExpenseLists");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestLists_Weddings_WeddingId",
                table: "GuestLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_GuestLists_GuestListId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Vendors_VendorID",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "ToDoTasks");

            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestLists",
                table: "GuestLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseLists",
                table: "ExpenseLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseItems",
                table: "ExpenseItems");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "Guest");

            migrationBuilder.RenameTable(
                name: "GuestLists",
                newName: "GuestList");

            migrationBuilder.RenameTable(
                name: "ExpenseLists",
                newName: "ExpenseList");

            migrationBuilder.RenameTable(
                name: "ExpenseItems",
                newName: "ExpenseItem");

            migrationBuilder.RenameColumn(
                name: "VendorID",
                table: "Photos",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_VendorID",
                table: "Photos",
                newName: "IX_Photos_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_GuestListId",
                table: "Guest",
                newName: "IX_Guest_GuestListId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestLists_WeddingId",
                table: "GuestList",
                newName: "IX_GuestList_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseLists_WeddingId",
                table: "ExpenseList",
                newName: "IX_ExpenseList_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseItems_ExpenseListId",
                table: "ExpenseItem",
                newName: "IX_ExpenseItem_ExpenseListId");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Photos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "Guest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestList",
                table: "GuestList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseList",
                table: "ExpenseList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseItem",
                table: "ExpenseItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseItem_ExpenseList_ExpenseListId",
                table: "ExpenseItem",
                column: "ExpenseListId",
                principalTable: "ExpenseList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseList_Weddings_WeddingId",
                table: "ExpenseList",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_GuestList_GuestListId",
                table: "Guest",
                column: "GuestListId",
                principalTable: "GuestList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestList_Weddings_WeddingId",
                table: "GuestList",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Vendors_VendorId",
                table: "Photos",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id");
        }
    }
}
