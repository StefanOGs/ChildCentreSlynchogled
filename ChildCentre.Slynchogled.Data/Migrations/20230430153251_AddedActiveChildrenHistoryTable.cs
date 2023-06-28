using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildCentre.Slynchogled.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedActiveChildrenHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveChildrenHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountName = table.Column<string>(type: "TEXT", nullable: false),
                    AccountPhone = table.Column<string>(type: "TEXT", nullable: false),
                    ChildNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ChildName = table.Column<string>(type: "TEXT", nullable: false),
                    ChildBirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SignedIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SignedOut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveChildrenHistory", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveChildrenHistory");
        }
    }
}
