using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hostel.Migrations
{
    public partial class addpaymentStuffs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountPayed",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCode",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentTime",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPayed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaymentCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaymentTime",
                table: "AspNetUsers");
        }
    }
}
