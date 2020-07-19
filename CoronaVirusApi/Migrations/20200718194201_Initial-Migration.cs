using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaVirusApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    InfectedNo = table.Column<int>(nullable: false),
                    RecoveredNo = table.Column<int>(nullable: false),
                    DeathNo = table.Column<int>(nullable: false),
                    RefreshDate = table.Column<DateTime>(nullable: false),
                    ContinentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "آسیا" },
                    { 2, "آمریکا" },
                    { 3, "آفریقا" },
                    { 4, "استرالیا" },
                    { 5, "اروپا" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "ContinentId", "DeathNo", "InfectedNo", "Name", "RecoveredNo", "RefreshDate" },
                values: new object[,]
                {
                    { 1, 1, 13500, 300000, "ایران", 250000, new DateTime(2020, 7, 18, 19, 42, 0, 800, DateTimeKind.Utc).AddTicks(7826) },
                    { 2, 2, 13500, 300000, "ایالات متحده آمریکا", 250000, new DateTime(2020, 7, 18, 19, 42, 0, 800, DateTimeKind.Utc).AddTicks(8584) },
                    { 4, 4, 5000, 30000, "سیدنی", 20000, new DateTime(2020, 7, 18, 19, 42, 0, 800, DateTimeKind.Utc).AddTicks(8599) },
                    { 3, 5, 100000, 2000000, "انگلیس", 1100000, new DateTime(2020, 7, 18, 19, 42, 0, 800, DateTimeKind.Utc).AddTicks(8597) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_ContinentId",
                table: "Country",
                column: "ContinentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
