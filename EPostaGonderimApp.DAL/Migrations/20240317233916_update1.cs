using Microsoft.EntityFrameworkCore.Migrations;

namespace EPostaGonderimApp.DAL.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KisiEPostalar");

            migrationBuilder.CreateTable(
                name: "EPostaKisi",
                columns: table => new
                {
                    EPostalarEPostaID = table.Column<int>(type: "int", nullable: false),
                    KisilerKisiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPostaKisi", x => new { x.EPostalarEPostaID, x.KisilerKisiID });
                    table.ForeignKey(
                        name: "FK_EPostaKisi_EPostalar_EPostalarEPostaID",
                        column: x => x.EPostalarEPostaID,
                        principalTable: "EPostalar",
                        principalColumn: "EPostaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EPostaKisi_Kisiler_KisilerKisiID",
                        column: x => x.KisilerKisiID,
                        principalTable: "Kisiler",
                        principalColumn: "KisiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EPostaKisi_KisilerKisiID",
                table: "EPostaKisi",
                column: "KisilerKisiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EPostaKisi");

            migrationBuilder.CreateTable(
                name: "KisiEPostalar",
                columns: table => new
                {
                    KisiID = table.Column<int>(type: "int", nullable: false),
                    EPostaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiEPostalar", x => new { x.KisiID, x.EPostaID });
                    table.ForeignKey(
                        name: "FK_KisiEPostalar_EPostalar_EPostaID",
                        column: x => x.EPostaID,
                        principalTable: "EPostalar",
                        principalColumn: "EPostaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KisiEPostalar_Kisiler_KisiID",
                        column: x => x.KisiID,
                        principalTable: "Kisiler",
                        principalColumn: "KisiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KisiEPostalar_EPostaID",
                table: "KisiEPostalar",
                column: "EPostaID");
        }
    }
}
