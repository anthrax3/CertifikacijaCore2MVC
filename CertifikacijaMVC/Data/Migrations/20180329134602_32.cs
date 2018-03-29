using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class _32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdabirTipa_Pitanje_PitanjeId",
                table: "OdabirTipa");

            migrationBuilder.DropForeignKey(
                name: "FK_OdabirTipa_TipPolaganja_TipPolaganjaId",
                table: "OdabirTipa");

            migrationBuilder.DropForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipa_OdabirTipaId",
                table: "OdgNaPitanjes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OdabirTipa",
                table: "OdabirTipa");

            migrationBuilder.RenameTable(
                name: "OdabirTipa",
                newName: "OdabirTipas");

            migrationBuilder.RenameIndex(
                name: "IX_OdabirTipa_TipPolaganjaId",
                table: "OdabirTipas",
                newName: "IX_OdabirTipas_TipPolaganjaId");

            migrationBuilder.RenameIndex(
                name: "IX_OdabirTipa_PitanjeId",
                table: "OdabirTipas",
                newName: "IX_OdabirTipas_PitanjeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OdabirTipas",
                table: "OdabirTipas",
                column: "OdabirTipaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OdabirTipas_Pitanje_PitanjeId",
                table: "OdabirTipas",
                column: "PitanjeId",
                principalTable: "Pitanje",
                principalColumn: "PitanjeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OdabirTipas_TipPolaganja_TipPolaganjaId",
                table: "OdabirTipas",
                column: "TipPolaganjaId",
                principalTable: "TipPolaganja",
                principalColumn: "TipPolaganjaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipas_OdabirTipaId",
                table: "OdgNaPitanjes",
                column: "OdabirTipaId",
                principalTable: "OdabirTipas",
                principalColumn: "OdabirTipaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdabirTipas_Pitanje_PitanjeId",
                table: "OdabirTipas");

            migrationBuilder.DropForeignKey(
                name: "FK_OdabirTipas_TipPolaganja_TipPolaganjaId",
                table: "OdabirTipas");

            migrationBuilder.DropForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipas_OdabirTipaId",
                table: "OdgNaPitanjes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OdabirTipas",
                table: "OdabirTipas");

            migrationBuilder.RenameTable(
                name: "OdabirTipas",
                newName: "OdabirTipa");

            migrationBuilder.RenameIndex(
                name: "IX_OdabirTipas_TipPolaganjaId",
                table: "OdabirTipa",
                newName: "IX_OdabirTipa_TipPolaganjaId");

            migrationBuilder.RenameIndex(
                name: "IX_OdabirTipas_PitanjeId",
                table: "OdabirTipa",
                newName: "IX_OdabirTipa_PitanjeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OdabirTipa",
                table: "OdabirTipa",
                column: "OdabirTipaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OdabirTipa_Pitanje_PitanjeId",
                table: "OdabirTipa",
                column: "PitanjeId",
                principalTable: "Pitanje",
                principalColumn: "PitanjeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OdabirTipa_TipPolaganja_TipPolaganjaId",
                table: "OdabirTipa",
                column: "TipPolaganjaId",
                principalTable: "TipPolaganja",
                principalColumn: "TipPolaganjaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipa_OdabirTipaId",
                table: "OdgNaPitanjes",
                column: "OdabirTipaId",
                principalTable: "OdabirTipa",
                principalColumn: "OdabirTipaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
