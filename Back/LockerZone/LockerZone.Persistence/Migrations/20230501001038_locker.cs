using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LockerZone.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class locker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lockers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    FromDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Last_Modified_By = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Last_Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lockers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lockers");
        }
    }
}
