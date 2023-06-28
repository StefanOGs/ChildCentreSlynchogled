using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildCentre.Slynchogled.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedActiveChildModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SignedIn",
                table: "ActiveChildren",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignedIn",
                table: "ActiveChildren");
        }
    }
}
