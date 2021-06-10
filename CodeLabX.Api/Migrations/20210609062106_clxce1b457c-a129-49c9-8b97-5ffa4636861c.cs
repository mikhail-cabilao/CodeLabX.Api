using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeLabX.Api.Migrations
{
    public partial class clxce1b457ca12949c98b975ffa4636861c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DictionaryCategory",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DictionaryCategory");
        }
    }
}
