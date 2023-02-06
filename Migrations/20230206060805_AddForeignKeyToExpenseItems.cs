using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelplannerservices.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToExpenseItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelItemId",
                table: "ExpenseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseItems_TravelItemId",
                table: "ExpenseItems",
                column: "TravelItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseItems_TravelItems_TravelItemId",
                table: "ExpenseItems",
                column: "TravelItemId",
                principalTable: "TravelItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseItems_TravelItems_TravelItemId",
                table: "ExpenseItems");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseItems_TravelItemId",
                table: "ExpenseItems");

            migrationBuilder.DropColumn(
                name: "TravelItemId",
                table: "ExpenseItems");
        }
    }
}
