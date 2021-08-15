using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeLabX.Api.Migrations
{
    public partial class clx6663615edafe4719acbdcc29fe54a51e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedData",
                table: "Topic",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedData",
                table: "Notebook",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedData",
                table: "DictionaryCategory",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedData",
                table: "Dictionary",
                newName: "ModifiedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Topic",
                newName: "ModifiedData");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Notebook",
                newName: "ModifiedData");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "DictionaryCategory",
                newName: "ModifiedData");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Dictionary",
                newName: "ModifiedData");
        }
    }
}
