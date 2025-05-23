﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verto.Migrations
{
    /// <inheritdoc />
    public partial class CircleImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CircleIconsImage",
                table: "HomePageContents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CircleIconsImage",
                table: "HomePageContents");
        }
    }
}
