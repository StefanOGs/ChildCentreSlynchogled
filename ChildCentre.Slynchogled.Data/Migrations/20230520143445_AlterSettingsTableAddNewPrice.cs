using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildCentre.Slynchogled.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterSettingsTableAddNewPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerHour",
                table: "Settings",
                newName: "PricePerHourWithParent");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerHourChildOnly",
                table: "Settings",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "WithParent",
                table: "ActiveChildrenHistory",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WithParent",
                table: "ActiveChildren",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerHourChildOnly",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "WithParent",
                table: "ActiveChildrenHistory");

            migrationBuilder.DropColumn(
                name: "WithParent",
                table: "ActiveChildren");

            migrationBuilder.RenameColumn(
                name: "PricePerHourWithParent",
                table: "Settings",
                newName: "PricePerHour");
        }
    }
}
