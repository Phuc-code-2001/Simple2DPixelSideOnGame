using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeathPoint = table.Column<float>(type: "real", nullable: false),
                    ManaPoint = table.Column<float>(type: "real", nullable: false),
                    Coin = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    SceneIndex = table.Column<int>(type: "int", nullable: false),
                    PositionX = table.Column<float>(type: "real", nullable: false),
                    PositionY = table.Column<float>(type: "real", nullable: false),
                    SaveTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Coin", "HeathPoint", "ManaPoint" },
                values: new object[] { 1, 5f, 1200f, 100f });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "PlayerId", "PositionX", "PositionY", "SaveTime", "SceneIndex" },
                values: new object[] { 1, 1, 0f, 0f, new DateTime(2022, 10, 7, 22, 14, 37, 109, DateTimeKind.Local).AddTicks(5486), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Records_PlayerId",
                table: "Records",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
