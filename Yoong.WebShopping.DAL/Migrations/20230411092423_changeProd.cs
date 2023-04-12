using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yoong.WebShopping.DAO.Migrations
{
    /// <inheritdoc />
    public partial class changeProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Img",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.AlterColumn<int>(
                name: "Geneder",
                table: "User",
                type: "int",
                maxLength: 250,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 250,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "Img");

            migrationBuilder.AlterColumn<int>(
                name: "Geneder",
                table: "User",
                type: "int",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 250);
        }
    }
}
