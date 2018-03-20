using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class _18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pitanje_TipPolaganja_TipPolaganjaId",
                table: "Pitanje");

            migrationBuilder.DropIndex(
                name: "IX_Pitanje_TipPolaganjaId",
                table: "Pitanje");

            migrationBuilder.DropColumn(
                name: "TipPolaganjaId",
                table: "Pitanje");

            migrationBuilder.CreateTable(
                name: "OdabirTipa",
                columns: table => new
                {
                    OdabirTipaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PitanjeId = table.Column<int>(nullable: false),
                    TipPolaganjaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdabirTipa", x => x.OdabirTipaId);
                    table.ForeignKey(
                        name: "FK_OdabirTipa_Pitanje_PitanjeId",
                        column: x => x.PitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "PitanjeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdabirTipa_TipPolaganja_TipPolaganjaId",
                        column: x => x.TipPolaganjaId,
                        principalTable: "TipPolaganja",
                        principalColumn: "TipPolaganjaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdabirTipa_PitanjeId",
                table: "OdabirTipa",
                column: "PitanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_OdabirTipa_TipPolaganjaId",
                table: "OdabirTipa",
                column: "TipPolaganjaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdabirTipa");

            migrationBuilder.AddColumn<int>(
                name: "TipPolaganjaId",
                table: "Pitanje",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_TipPolaganjaId",
                table: "Pitanje",
                column: "TipPolaganjaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pitanje_TipPolaganja_TipPolaganjaId",
                table: "Pitanje",
                column: "TipPolaganjaId",
                principalTable: "TipPolaganja",
                principalColumn: "TipPolaganjaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
