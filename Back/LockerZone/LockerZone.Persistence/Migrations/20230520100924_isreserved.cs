using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LockerZone.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class isreserved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Lockers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Lockers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Lockers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lockers");
        }
    }
}
