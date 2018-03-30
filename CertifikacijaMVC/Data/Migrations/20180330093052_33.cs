using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class _33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipOdgovora",
                table: "OdgNaPitanjes",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipOdgovora",
                table: "OdgNaPitanjes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
