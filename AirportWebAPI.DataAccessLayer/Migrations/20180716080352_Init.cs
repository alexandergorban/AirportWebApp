using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportWebAPI.DataAccessLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirplaneTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Model = table.Column<string>(maxLength: 30, nullable: false),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    LoadCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneTypes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Experience = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    AirplaneTypeId = table.Column<Guid>(nullable: false),
                    DateOfIssue = table.Column<DateTime>(nullable: false),
                    LifeTime = table.Column<TimeSpan>(nullable: false),
                    IsOwnAirplane = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airplanes_AirplaneTypes_AirplaneTypeId",
                        column: x => x.AirplaneTypeId,
                        principalTable: "AirplaneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FlightNumber = table.Column<string>(maxLength: 10, nullable: false),
                    DeparturePointId = table.Column<Guid>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    DestinationPointId = table.Column<Guid>(nullable: true),
                    ArrivalTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_AirportLocations_DeparturePointId",
                        column: x => x.DeparturePointId,
                        principalTable: "AirportLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_AirportLocations_DestinationPointId",
                        column: x => x.DestinationPointId,
                        principalTable: "AirportLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PilotId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crews_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<long>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    IsFlightDelay = table.Column<bool>(nullable: false),
                    DepartureTimeChanged = table.Column<DateTime>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: false),
                    CrewId = table.Column<Guid>(nullable: false),
                    AirplaneId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departures_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departures_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departures_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stewardesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CrewId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stewardesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stewardesses_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airplanes_AirplaneTypeId",
                table: "Airplanes",
                column: "AirplaneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_PilotId",
                table: "Crews",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Departures_AirplaneId",
                table: "Departures",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Departures_CrewId",
                table: "Departures",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Departures_FlightId",
                table: "Departures",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DeparturePointId",
                table: "Flights",
                column: "DeparturePointId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DestinationPointId",
                table: "Flights",
                column: "DestinationPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Stewardesses_CrewId",
                table: "Stewardesses",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "Stewardesses");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "AirplaneTypes");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "AirportLocations");
        }
    }
}
