using Microsoft.EntityFrameworkCore.Migrations;

namespace TISklep.Migrations
{
    public partial class DodanieDlugosci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DlugoscFilmu",
                table: "Filmy",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DlugoscFilmu",
                table: "Filmy");
        }
    }
}
