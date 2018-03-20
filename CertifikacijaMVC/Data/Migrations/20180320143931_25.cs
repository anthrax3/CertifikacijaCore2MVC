using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class _25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipa_OdabirTipaId",
                table: "OdgNaPitanjes");

            migrationBuilder.DropColumn(
                name: "PitanjeId",
                table: "OdgNaPitanjes");

            migrationBuilder.AlterColumn<int>(
                name: "OdabirTipaId",
                table: "OdgNaPitanjes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipa_OdabirTipaId",
                table: "OdgNaPitanjes",
                column: "OdabirTipaId",
                principalTable: "OdabirTipa",
                principalColumn: "OdabirTipaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipa_OdabirTipaId",
                table: "OdgNaPitanjes");

            migrationBuilder.AlterColumn<int>(
                name: "OdabirTipaId",
                table: "OdgNaPitanjes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PitanjeId",
                table: "OdgNaPitanjes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OdgNaPitanjes_OdabirTipa_OdabirTipaId",
                table: "OdgNaPitanjes",
                column: "OdabirTipaId",
                principalTable: "OdabirTipa",
                principalColumn: "OdabirTipaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
