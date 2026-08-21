using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGTS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Agregandoconfiguracionacategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categorias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, null, "Hardware" },
                    { 2, null, "Software" },
                    { 3, null, "Redes y Conectividad" },
                    { 4, null, "Sistemas Operativos" },
                    { 5, null, "Accesos y Credenciales" },
                    { 6, null, "Impresoras y Periféricos" },
                    { 7, null, "Correo Electrónico" },
                    { 8, null, "Aplicaciones Institucionales" },
                    { 9, null, "Soporte al Usuario" },
                    { 10, null, "Otros" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
