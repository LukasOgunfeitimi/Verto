using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verto.Migrations
{
    /// <inheritdoc />
    public partial class RevertBackToOldTexts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderTexts");

            migrationBuilder.AddColumn<string>(
                name: "SliderDesc1",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderDesc2",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderDesc3",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderTitle1",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderTitle2",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderTitle3",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderDesc1",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "SliderDesc2",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "SliderDesc3",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "SliderTitle1",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "SliderTitle2",
                table: "HomePageContents");

            migrationBuilder.DropColumn(
                name: "SliderTitle3",
                table: "HomePageContents");

            migrationBuilder.CreateTable(
                name: "SliderTexts",
                columns: table => new
                {
                    HomePageContentId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderTexts", x => new { x.HomePageContentId, x.Id });
                    table.ForeignKey(
                        name: "FK_SliderTexts_HomePageContents_HomePageContentId",
                        column: x => x.HomePageContentId,
                        principalTable: "HomePageContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
