using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class _22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OdgNaPitanjes",
                columns: table => new
                {
                    OdgNaPitanjeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OdgovorId = table.Column<int>(nullable: false),
                    PitanjeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdgNaPitanjes", x => x.OdgNaPitanjeId);
                    table.ForeignKey(
                        name: "FK_OdgNaPitanjes_Odgovor_OdgovorId",
                        column: x => x.OdgovorId,
                        principalTable: "Odgovor",
                        principalColumn: "OdgovorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdgNaPitanjes_Pitanje_PitanjeId",
                        column: x => x.PitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "PitanjeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdgNaPitanjes_OdgovorId",
                table: "OdgNaPitanjes",
                column: "OdgovorId");

            migrationBuilder.CreateIndex(
                name: "IX_OdgNaPitanjes_PitanjeId",
                table: "OdgNaPitanjes",
                column: "PitanjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdgNaPitanjes");
        }
    }
}
