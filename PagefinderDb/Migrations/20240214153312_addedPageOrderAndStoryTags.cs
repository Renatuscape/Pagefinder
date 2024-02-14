using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PagefinderDb.Migrations
{
    /// <inheritdoc />
    public partial class addedPageOrderAndStoryTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Pages");
        }
    }
}
