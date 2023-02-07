using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelplannerservices.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTravelItemsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "TravelItems");

            migrationBuilder.AddColumn<int>(
                name: "Budget",
                table: "TravelItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "TravelItems");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "TravelItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
