using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class _23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tačno",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "TipOdgovora",
                table: "Odgovor");

            migrationBuilder.AddColumn<bool>(
                name: "Tačno",
                table: "OdgNaPitanjes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TipOdgovora",
                table: "OdgNaPitanjes",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tačno",
                table: "OdgNaPitanjes");

            migrationBuilder.DropColumn(
                name: "TipOdgovora",
                table: "OdgNaPitanjes");

            migrationBuilder.AddColumn<bool>(
                name: "Tačno",
                table: "Odgovor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TipOdgovora",
                table: "Odgovor",
                nullable: false,
                defaultValue: "");
        }
    }
}
