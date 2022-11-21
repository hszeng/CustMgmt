using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustMgmt.Migrations
{
    public partial class AddOptimisticLock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Notes",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Customers",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Customers");
        }
    }
}
