using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class Treci : Migration
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

            migrationBuilder.RenameColumn(
                name: "bodovi",
                table: "Rezultat",
                newName: "Bodovi");

            migrationBuilder.AlterColumn<string>(
                name: "TipEng",
                table: "TipPolaganja",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tip",
                table: "TipPolaganja",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PitanjeId",
                table: "TipPolaganja",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TekstPitanja",
                table: "Pitanje",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipOdgovora",
                table: "Odgovor",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TekstOdgovora",
                table: "Odgovor",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Bodovi",
                table: "Rezultat",
                newName: "bodovi");

            migrationBuilder.AlterColumn<string>(
                name: "TipEng",
                table: "TipPolaganja",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Tip",
                table: "TipPolaganja",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TekstPitanja",
                table: "Pitanje",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "TipPolaganjaId",
                table: "Pitanje",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipOdgovora",
                table: "Odgovor",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TekstOdgovora",
                table: "Odgovor",
                nullable: true,
                oldClrType: typeof(string));

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
