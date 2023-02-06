using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelplannerservices.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelItems_ExpenseItems_ExpenseItemId",
                table: "TravelItems");

            migrationBuilder.DropIndex(
                name: "IX_TravelItems_ExpenseItemId",
                table: "TravelItems");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "TravelItems");

            migrationBuilder.DropColumn(
                name: "ExpenseItemId",
                table: "TravelItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "TravelItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpenseItemId",
                table: "TravelItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TravelItems_ExpenseItemId",
                table: "TravelItems",
                column: "ExpenseItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelItems_ExpenseItems_ExpenseItemId",
                table: "TravelItems",
                column: "ExpenseItemId",
                principalTable: "ExpenseItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
