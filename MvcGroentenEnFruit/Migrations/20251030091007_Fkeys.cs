using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcGroentenEnFruit.Migrations
{
    /// <inheritdoc />
    public partial class Fkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VerkoopOrders_ArtikelId",
                table: "VerkoopOrders",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_AankoopOrders_ArtikelId",
                table: "AankoopOrders",
                column: "ArtikelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AankoopOrders_Artikels_ArtikelId",
                table: "AankoopOrders",
                column: "ArtikelId",
                principalTable: "Artikels",
                principalColumn: "ArtikelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VerkoopOrders_Artikels_ArtikelId",
                table: "VerkoopOrders",
                column: "ArtikelId",
                principalTable: "Artikels",
                principalColumn: "ArtikelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AankoopOrders_Artikels_ArtikelId",
                table: "AankoopOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_VerkoopOrders_Artikels_ArtikelId",
                table: "VerkoopOrders");

            migrationBuilder.DropIndex(
                name: "IX_VerkoopOrders_ArtikelId",
                table: "VerkoopOrders");

            migrationBuilder.DropIndex(
                name: "IX_AankoopOrders_ArtikelId",
                table: "AankoopOrders");
        }
    }
}
