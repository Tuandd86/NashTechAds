using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NashTechAdsAPI.Migrations
{
    public partial class AddedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Ads",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Ads");
        }
    }
}
