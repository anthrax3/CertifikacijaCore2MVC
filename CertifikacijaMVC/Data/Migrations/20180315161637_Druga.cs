using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class Druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipEng",
                table: "TipPolaganja",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipOdgovora",
                table: "Odgovor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipEng",
                table: "TipPolaganja");

            migrationBuilder.DropColumn(
                name: "TipOdgovora",
                table: "Odgovor");
        }
    }
}
