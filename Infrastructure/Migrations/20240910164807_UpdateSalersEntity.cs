using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateSalersEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salerStocks_Beers_BeerId",
                table: "salerStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_salerStocks_Salers_SalerId",
                table: "salerStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_salerStocks",
                table: "salerStocks");

            migrationBuilder.DropIndex(
                name: "IX_salerStocks_BeerId",
                table: "salerStocks");

            migrationBuilder.RenameTable(
                name: "salerStocks",
                newName: "SalerStocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalerStocks",
                table: "SalerStocks",
                columns: new[] { "SalerId", "BeerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SalerStocks_Salers_SalerId",
                table: "SalerStocks",
                column: "SalerId",
                principalTable: "Salers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalerStocks_Salers_SalerId",
                table: "SalerStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalerStocks",
                table: "SalerStocks");

            migrationBuilder.RenameTable(
                name: "SalerStocks",
                newName: "salerStocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_salerStocks",
                table: "salerStocks",
                columns: new[] { "SalerId", "BeerId" });

            migrationBuilder.CreateIndex(
                name: "IX_salerStocks_BeerId",
                table: "salerStocks",
                column: "BeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_salerStocks_Beers_BeerId",
                table: "salerStocks",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salerStocks_Salers_SalerId",
                table: "salerStocks",
                column: "SalerId",
                principalTable: "Salers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
