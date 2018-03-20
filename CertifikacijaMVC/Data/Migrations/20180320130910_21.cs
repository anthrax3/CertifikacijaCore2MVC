using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class _21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certifikati",
                columns: table => new
                {
                    CertifikatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    DjelovodniBroj = table.Column<string>(nullable: false),
                    RezultatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifikati", x => x.CertifikatId);
                    table.ForeignKey(
                        name: "FK_Certifikati_Rezultat_RezultatId",
                        column: x => x.RezultatId,
                        principalTable: "Rezultat",
                        principalColumn: "RezultatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certifikati_RezultatId",
                table: "Certifikati",
                column: "RezultatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certifikati");
        }
    }
}
