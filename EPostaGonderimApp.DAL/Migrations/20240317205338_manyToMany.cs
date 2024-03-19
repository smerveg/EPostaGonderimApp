using Microsoft.EntityFrameworkCore.Migrations;

namespace EPostaGonderimApp.DAL.Migrations
{
    public partial class manyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EPosta_EPostaAdresleri_EPostaAdresID",
                table: "EPosta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EPosta",
                table: "EPosta");

            migrationBuilder.RenameTable(
                name: "EPosta",
                newName: "EPostalar");

            migrationBuilder.RenameIndex(
                name: "IX_EPosta_EPostaAdresID",
                table: "EPostalar",
                newName: "IX_EPostalar_EPostaAdresID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EPostalar",
                table: "EPostalar",
                column: "EPostaID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EPostalar_EPostaAdresleri_EPostaAdresID",
                table: "EPostalar",
                column: "EPostaAdresID",
                principalTable: "EPostaAdresleri",
                principalColumn: "EPostaAdresID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EPostalar_EPostaAdresleri_EPostaAdresID",
                table: "EPostalar");

            migrationBuilder.DropTable(
                name: "KisiEPostalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EPostalar",
                table: "EPostalar");

            migrationBuilder.RenameTable(
                name: "EPostalar",
                newName: "EPosta");

            migrationBuilder.RenameIndex(
                name: "IX_EPostalar_EPostaAdresID",
                table: "EPosta",
                newName: "IX_EPosta_EPostaAdresID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EPosta",
                table: "EPosta",
                column: "EPostaID");

            migrationBuilder.AddForeignKey(
                name: "FK_EPosta_EPostaAdresleri_EPostaAdresID",
                table: "EPosta",
                column: "EPostaAdresID",
                principalTable: "EPostaAdresleri",
                principalColumn: "EPostaAdresID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
