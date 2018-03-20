using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class Sesti : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
