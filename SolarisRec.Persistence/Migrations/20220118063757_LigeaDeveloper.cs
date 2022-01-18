using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarisRec.Persistence.Migrations
{
    public partial class LigeaDeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CardTalents",
                columns: new[] { "CardId", "TalentId", "Quantity" },
                values: new object[] { 100, 2, 2 });

            migrationBuilder.InsertData(
                table: "CardTalents",
                columns: new[] { "CardId", "TalentId", "Quantity" },
                values: new object[] { 100, 4, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CardTalents",
                keyColumns: new[] { "CardId", "TalentId" },
                keyValues: new object[] { 100, 2 });

            migrationBuilder.DeleteData(
                table: "CardTalents",
                keyColumns: new[] { "CardId", "TalentId" },
                keyValues: new object[] { 100, 4 });
        }
    }
}
