using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okane.Storage.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAtProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Expenses",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Expenses");
        }
    }
}
