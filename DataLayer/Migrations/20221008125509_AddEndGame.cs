using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddEndGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EndGame",
                table: "Records",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveTime",
                value: new DateTime(2022, 10, 8, 19, 55, 8, 954, DateTimeKind.Local).AddTicks(943));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndGame",
                table: "Records");

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveTime",
                value: new DateTime(2022, 10, 8, 19, 53, 45, 827, DateTimeKind.Local).AddTicks(3308));
        }
    }
}
