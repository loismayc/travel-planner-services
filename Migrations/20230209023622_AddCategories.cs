using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelplannerservices.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ExpenseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseItems_CategoryId",
                table: "ExpenseItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseItems_Categories_CategoryId",
                table: "ExpenseItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseItems_Categories_CategoryId",
                table: "ExpenseItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseItems_CategoryId",
                table: "ExpenseItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ExpenseItems");
        }
    }
}
