using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Emp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pozicie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazov = table.Column<string>(nullable: false),
                    Vymazana = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozicie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zamestnanci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    DatumNarodenia = table.Column<DateTime>(nullable: false),
                    Meno = table.Column<string>(nullable: false),
                    Priezvisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamestnanci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvidenciaZamestnancov",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumNastupu = table.Column<DateTime>(nullable: false),
                    DatumUkoncenia = table.Column<DateTime>(nullable: true),
                    Plat = table.Column<float>(nullable: false),
                    PoziciaId = table.Column<int>(nullable: false),
                    ZamestnanecId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenciaZamestnancov", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvidenciaZamestnancov_Pozicie_PoziciaId",
                        column: x => x.PoziciaId,
                        principalTable: "Pozicie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvidenciaZamestnancov_Zamestnanci_ZamestnanecId",
                        column: x => x.ZamestnanecId,
                        principalTable: "Zamestnanci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvidenciaZamestnancov_PoziciaId",
                table: "EvidenciaZamestnancov",
                column: "PoziciaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenciaZamestnancov_ZamestnanecId",
                table: "EvidenciaZamestnancov",
                column: "ZamestnanecId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvidenciaZamestnancov");

            migrationBuilder.DropTable(
                name: "Pozicie");

            migrationBuilder.DropTable(
                name: "Zamestnanci");
        }
    }
}
