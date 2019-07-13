using Microsoft.EntityFrameworkCore.Migrations;

namespace NashTechAdsAPI.Migrations
{
    public partial class AddedAdStatusAndCreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Ads",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Ads",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ads");
        }
    }
}
