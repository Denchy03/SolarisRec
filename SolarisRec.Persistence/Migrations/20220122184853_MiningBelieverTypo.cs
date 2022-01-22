using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarisRec.Persistence.Migrations
{
    public partial class MiningBelieverTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "Mining Believer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "MiningBeliever");
        }
    }
}
