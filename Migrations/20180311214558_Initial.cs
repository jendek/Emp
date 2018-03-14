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
                    PoziciaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazov = table.Column<string>(nullable: false),
                    Vymazana = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozicie", x => x.PoziciaID);
                });

            migrationBuilder.CreateTable(
                name: "Zamestnanci",
                columns: table => new
                {
                    ZamestnanecID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    DatumNarodenia = table.Column<DateTime>(nullable: false),
                    Meno = table.Column<string>(nullable: false),
                    Priezvisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamestnanci", x => x.ZamestnanecID);
                });

            migrationBuilder.CreateTable(
                name: "EvidenciaZamestnancov",
                columns: table => new
                {
                    EvidenciaZamestnancaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumNastupu = table.Column<DateTime>(nullable: false),
                    DatumUkoncenia = table.Column<DateTime>(nullable: true),
                    Plat = table.Column<float>(nullable: false),
                    PoziciaID = table.Column<int>(nullable: false),
                    ZamestnanecID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenciaZamestnancov", x => x.EvidenciaZamestnancaID);
                    table.ForeignKey(
                        name: "FK_EvidenciaZamestnancov_Pozicie_PoziciaID",
                        column: x => x.PoziciaID,
                        principalTable: "Pozicie",
                        principalColumn: "PoziciaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvidenciaZamestnancov_Zamestnanci_ZamestnanecID",
                        column: x => x.ZamestnanecID,
                        principalTable: "Zamestnanci",
                        principalColumn: "ZamestnanecID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvidenciaZamestnancov_PoziciaID",
                table: "EvidenciaZamestnancov",
                column: "PoziciaID");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenciaZamestnancov_ZamestnanecID",
                table: "EvidenciaZamestnancov",
                column: "ZamestnanecID");
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
