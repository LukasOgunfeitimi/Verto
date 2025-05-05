using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verto.Migrations
{
    /// <inheritdoc />
    public partial class BetterDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "SliderImage1",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "SliderImage2",
                table: "HomePageContents");

            migrationBuilder.RenameColumn(
                name: "SliderImage3",
                table: "HomePageContents",
                newName: "MainImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MainImage",
                table: "HomePageContents",
                newName: "SliderImage3");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderImage1",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderImage2",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
