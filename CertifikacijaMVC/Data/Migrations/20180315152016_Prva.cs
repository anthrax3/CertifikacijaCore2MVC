using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CertifikacijaMVC.Data.Migrations
{
    public partial class Prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "TipPolaganja",
                columns: table => new
                {
                    TipPolaganjaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPolaganja", x => x.TipPolaganjaId);
                });

            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    PitanjeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TekstPitanja = table.Column<string>(nullable: true),
                    TipPolaganjaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.PitanjeId);
                    table.ForeignKey(
                        name: "FK_Pitanje_TipPolaganja_TipPolaganjaId",
                        column: x => x.TipPolaganjaId,
                        principalTable: "TipPolaganja",
                        principalColumn: "TipPolaganjaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezultat",
                columns: table => new
                {
                    RezultatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPolaganja = table.Column<DateTime>(nullable: false),
                    Pokusaj = table.Column<int>(nullable: false),
                    TipPolaganjaId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    bodovi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezultat", x => x.RezultatId);
                    table.ForeignKey(
                        name: "FK_Rezultat_TipPolaganja_TipPolaganjaId",
                        column: x => x.TipPolaganjaId,
                        principalTable: "TipPolaganja",
                        principalColumn: "TipPolaganjaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezultat_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odgovor",
                columns: table => new
                {
                    OdgovorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PitanjeId = table.Column<int>(nullable: true),
                    Tačno = table.Column<bool>(nullable: false),
                    TekstOdgovora = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odgovor", x => x.OdgovorId);
                    table.ForeignKey(
                        name: "FK_Odgovor_Pitanje_PitanjeId",
                        column: x => x.PitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "PitanjeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OdgovorId = table.Column<int>(nullable: false),
                    PitanjeId = table.Column<int>(nullable: false),
                    RezultatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Test_Odgovor_OdgovorId",
                        column: x => x.OdgovorId,
                        principalTable: "Odgovor",
                        principalColumn: "OdgovorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Test_Pitanje_PitanjeId",
                        column: x => x.PitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "PitanjeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Test_Rezultat_RezultatId",
                        column: x => x.RezultatId,
                        principalTable: "Rezultat",
                        principalColumn: "RezultatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Odgovor_PitanjeId",
                table: "Odgovor",
                column: "PitanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_TipPolaganjaId",
                table: "Pitanje",
                column: "TipPolaganjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezultat_TipPolaganjaId",
                table: "Rezultat",
                column: "TipPolaganjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezultat_UserId",
                table: "Rezultat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_OdgovorId",
                table: "Test",
                column: "OdgovorId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_PitanjeId",
                table: "Test",
                column: "PitanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_RezultatId",
                table: "Test",
                column: "RezultatId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Odgovor");

            migrationBuilder.DropTable(
                name: "Rezultat");

            migrationBuilder.DropTable(
                name: "Pitanje");

            migrationBuilder.DropTable(
                name: "TipPolaganja");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
