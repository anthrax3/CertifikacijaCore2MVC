using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class _24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdgNaPitanjes_Pitanje_PitanjeId",
                table: "OdgNaPitanjes");

            migrationBuilder.DropIndex(
                name: "IX_OdgNaPitanjes_PitanjeId",
                table: "OdgNaPitanjes");

            migrationBuilder.AddColumn<int>(
                name: "OdabirTipaId",
                table: "OdgNaPitanjes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OdgNaPitanjes_OdabirTipaId",
                table: "OdgNaPitanjes",
                column: "OdabirTipaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipa_OdabirTipaId",
                table: "OdgNaPitanjes",
                column: "OdabirTipaId",
                principalTable: "OdabirTipa",
                principalColumn: "OdabirTipaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipa_OdabirTipaId",
                table: "OdgNaPitanjes");

            migrationBuilder.DropIndex(
                name: "IX_OdgNaPitanjes_OdabirTipaId",
                table: "OdgNaPitanjes");

            migrationBuilder.DropColumn(
                name: "OdabirTipaId",
                table: "OdgNaPitanjes");

            migrationBuilder.CreateIndex(
                name: "IX_OdgNaPitanjes_PitanjeId",
                table: "OdgNaPitanjes",
                column: "PitanjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OdgNaPitanjes_Pitanje_PitanjeId",
                table: "OdgNaPitanjes",
                column: "PitanjeId",
                principalTable: "Pitanje",
                principalColumn: "PitanjeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
