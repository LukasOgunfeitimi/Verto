using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verto.Migrations
{
    /// <inheritdoc />
    public partial class PushDiscoverImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscoverImage",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscoverImage",
                table: "HomePageContents");
        }
    }
}
