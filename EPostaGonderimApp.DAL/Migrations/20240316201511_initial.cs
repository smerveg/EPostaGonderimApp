using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPostaGonderimApp.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EPostaAdresleri",
                columns: table => new
                {
                    EPostaAdresID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailSunucuAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPostaAdresleri", x => x.EPostaAdresID);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    KisiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EPostaAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvTelefonu = table.Column<int>(type: "int", nullable: false),
                    CepTelefonu = table.Column<int>(type: "int", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsYeriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.KisiID);
                });

            migrationBuilder.CreateTable(
                name: "EPosta",
                columns: table => new
                {
                    EPostaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GonderimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderimDurumu = table.Column<bool>(type: "bit", nullable: false),
                    EPostaAdresID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPosta", x => x.EPostaID);
                    table.ForeignKey(
                        name: "FK_EPosta_EPostaAdresleri_EPostaAdresID",
                        column: x => x.EPostaAdresID,
                        principalTable: "EPostaAdresleri",
                        principalColumn: "EPostaAdresID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EPosta_EPostaAdresID",
                table: "EPosta",
                column: "EPostaAdresID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EPosta");

            migrationBuilder.DropTable(
                name: "Kisiler");

            migrationBuilder.DropTable(
                name: "EPostaAdresleri");
        }
    }
}
