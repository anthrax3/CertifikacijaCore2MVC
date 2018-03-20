using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipPolaganja_Pitanje_PitanjeId",
                table: "TipPolaganja");

            migrationBuilder.DropIndex(
                name: "IX_TipPolaganja_PitanjeId",
                table: "TipPolaganja");

            migrationBuilder.DropColumn(
                name: "PitanjeId",
                table: "TipPolaganja");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PitanjeId",
                table: "TipPolaganja",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipPolaganja_PitanjeId",
                table: "TipPolaganja",
                column: "PitanjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipPolaganja_Pitanje_PitanjeId",
                table: "TipPolaganja",
                column: "PitanjeId",
                principalTable: "Pitanje",
                principalColumn: "PitanjeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
