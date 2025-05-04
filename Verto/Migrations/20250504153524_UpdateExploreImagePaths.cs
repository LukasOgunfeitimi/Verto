using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verto.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExploreImagePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExploreImage1",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExploreImage2",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExploreImage3",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExploreImage1",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "ExploreImage2",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "ExploreImage3",
                table: "HomePageContents");
        }
    }
}
