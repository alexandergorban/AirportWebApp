using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportWebAPI.DataAccessLayer.Migrations
{
    public partial class AirportDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirportLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AirportName = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportLocations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportLocations");
        }
    }
}
