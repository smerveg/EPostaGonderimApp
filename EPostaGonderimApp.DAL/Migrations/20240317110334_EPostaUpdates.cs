using Microsoft.EntityFrameworkCore.Migrations;

namespace EPostaGonderimApp.DAL.Migrations
{
    public partial class EPostaUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icerik",
                table: "EPosta",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icerik",
                table: "EPosta");
        }
    }
}
