using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGTS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullRolDepartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosAsignaciones_Departamentos_IdDepartamento",
                table: "UsuariosAsignaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosAsignaciones_Roles_IdRol",
                table: "UsuariosAsignaciones");

            migrationBuilder.AlterColumn<int>(
                name: "IdRol",
                table: "UsuariosAsignaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdDepartamento",
                table: "UsuariosAsignaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosAsignaciones_Departamentos_IdDepartamento",
                table: "UsuariosAsignaciones",
                column: "IdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosAsignaciones_Roles_IdRol",
                table: "UsuariosAsignaciones",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosAsignaciones_Departamentos_IdDepartamento",
                table: "UsuariosAsignaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosAsignaciones_Roles_IdRol",
                table: "UsuariosAsignaciones");

            migrationBuilder.AlterColumn<int>(
                name: "IdRol",
                table: "UsuariosAsignaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDepartamento",
                table: "UsuariosAsignaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosAsignaciones_Departamentos_IdDepartamento",
                table: "UsuariosAsignaciones",
                column: "IdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosAsignaciones_Roles_IdRol",
                table: "UsuariosAsignaciones",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
