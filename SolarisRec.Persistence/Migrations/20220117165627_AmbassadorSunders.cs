using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarisRec.Persistence.Migrations
{
    public partial class AmbassadorSunders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CardTalents",
                columns: new[] { "CardId", "TalentId", "Quantity" },
                values: new object[] { 36, 1, 1 });

            migrationBuilder.InsertData(
                table: "CardTalents",
                columns: new[] { "CardId", "TalentId", "Quantity" },
                values: new object[] { 36, 3, 1 });

            migrationBuilder.InsertData(
                table: "CardTalents",
                columns: new[] { "CardId", "TalentId", "Quantity" },
                values: new object[] { 36, 5, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CardTalents",
                keyColumns: new[] { "CardId", "TalentId" },
                keyValues: new object[] { 36, 1 });

            migrationBuilder.DeleteData(
                table: "CardTalents",
                keyColumns: new[] { "CardId", "TalentId" },
                keyValues: new object[] { 36, 3 });

            migrationBuilder.DeleteData(
                table: "CardTalents",
                keyColumns: new[] { "CardId", "TalentId" },
                keyValues: new object[] { 36, 5 });
        }
    }
}
