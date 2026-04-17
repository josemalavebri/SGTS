using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGTS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImageNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problemas_Imagenes_ImagenId",
                table: "Problemas");

            migrationBuilder.AlterColumn<int>(
                name: "ImagenId",
                table: "Problemas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Problemas_Imagenes_ImagenId",
                table: "Problemas",
                column: "ImagenId",
                principalTable: "Imagenes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problemas_Imagenes_ImagenId",
                table: "Problemas");

            migrationBuilder.AlterColumn<int>(
                name: "ImagenId",
                table: "Problemas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Problemas_Imagenes_ImagenId",
                table: "Problemas",
                column: "ImagenId",
                principalTable: "Imagenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
