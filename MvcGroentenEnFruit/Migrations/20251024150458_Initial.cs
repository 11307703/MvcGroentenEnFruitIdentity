using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcGroentenEnFruit.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AankoopOrders",
                columns: table => new
                {
                    AankoopOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hoeveelheid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AankoopOrders", x => x.AankoopOrderId);
                });

            migrationBuilder.CreateTable(
                name: "Artikels",
                columns: table => new
                {
                    ArtikelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtikelNaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikels", x => x.ArtikelId);
                });

            migrationBuilder.CreateTable(
                name: "VerkoopOrders",
                columns: table => new
                {
                    VerkoopOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hoeveelheid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerkoopOrders", x => x.VerkoopOrderId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AankoopOrders");

            migrationBuilder.DropTable(
                name: "Artikels");

            migrationBuilder.DropTable(
                name: "VerkoopOrders");
        }
    }
}
