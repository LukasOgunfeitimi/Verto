using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verto.Migrations
{
    /// <inheritdoc />
    public partial class PushFeatureImagea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeatureImage1",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeatureImage2",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeatureImage3",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeatureImage4",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeatureImage1",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "FeatureImage2",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "FeatureImage3",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "FeatureImage4",
                table: "HomePageContents");
        }
    }
}
