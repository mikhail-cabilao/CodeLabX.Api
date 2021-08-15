using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeLabX.Api.Migrations
{
    public partial class clx42b55fdcd4a54d5380ccc2bbbe7028f2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dictionary_DictionaryCategory_CategoryId",
                table: "Dictionary");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Dictionary",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Dictionary_DictionaryCategory_CategoryId",
                table: "Dictionary",
                column: "CategoryId",
                principalTable: "DictionaryCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dictionary_DictionaryCategory_CategoryId",
                table: "Dictionary");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Dictionary",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dictionary_DictionaryCategory_CategoryId",
                table: "Dictionary",
                column: "CategoryId",
                principalTable: "DictionaryCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
