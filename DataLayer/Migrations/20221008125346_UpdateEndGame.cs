using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class UpdateEndGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveTime",
                value: new DateTime(2022, 10, 8, 19, 53, 45, 827, DateTimeKind.Local).AddTicks(3308));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveTime",
                value: new DateTime(2022, 10, 7, 22, 14, 37, 109, DateTimeKind.Local).AddTicks(5486));
        }
    }
}
