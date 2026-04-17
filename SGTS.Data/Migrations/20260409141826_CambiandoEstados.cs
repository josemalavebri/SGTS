using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGTS.Data.Migrations
{
    /// <inheritdoc />
    public partial class CambiandoEstados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problemas_EstadosProblemas_EstadoProblemaId",
                table: "Problemas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemasResoluciones_Problemas_ProblemaId",
                table: "ProblemasResoluciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemasResoluciones_Tecnicos_TecnicoId",
                table: "ProblemasResoluciones");

            migrationBuilder.DropTable(
                name: "EstadosProblemas");

            migrationBuilder.DropIndex(
                name: "IX_Problemas_EstadoProblemaId",
                table: "Problemas");

            migrationBuilder.DropColumn(
                name: "Especialidad",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "ProblemasResoluciones");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ProblemasResoluciones");

            migrationBuilder.DropColumn(
                name: "EstadoProblemaId",
                table: "Problemas");

            migrationBuilder.DropColumn(
                name: "FechaResolucion",
                table: "Problemas");

            migrationBuilder.RenameColumn(
                name: "ProblemaId",
                table: "ProblemasResoluciones",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "ProblemasResoluciones",
                newName: "FechaCambio");

            migrationBuilder.RenameIndex(
                name: "IX_ProblemasResoluciones_ProblemaId",
                table: "ProblemasResoluciones",
                newName: "IX_ProblemasResoluciones_TicketId");

            migrationBuilder.AlterColumn<int>(
                name: "TecnicoId",
                table: "ProblemasResoluciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EstadoTicketId",
                table: "ProblemasResoluciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Problemas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "abierto" },
                    { 2, "en-progreso" },
                    { 3, "resuelto" },
                    { 4, "cerrado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemasResoluciones_EstadoTicketId",
                table: "ProblemasResoluciones",
                column: "EstadoTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemasResoluciones_Estados_EstadoTicketId",
                table: "ProblemasResoluciones",
                column: "EstadoTicketId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemasResoluciones_Problemas_TicketId",
                table: "ProblemasResoluciones",
                column: "TicketId",
                principalTable: "Problemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemasResoluciones_Usuarios_TecnicoId",
                table: "ProblemasResoluciones",
                column: "TecnicoId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemasResoluciones_Estados_EstadoTicketId",
                table: "ProblemasResoluciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemasResoluciones_Problemas_TicketId",
                table: "ProblemasResoluciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemasResoluciones_Usuarios_TecnicoId",
                table: "ProblemasResoluciones");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_ProblemasResoluciones_EstadoTicketId",
                table: "ProblemasResoluciones");

            migrationBuilder.DropColumn(
                name: "EstadoTicketId",
                table: "ProblemasResoluciones");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "ProblemasResoluciones",
                newName: "ProblemaId");

            migrationBuilder.RenameColumn(
                name: "FechaCambio",
                table: "ProblemasResoluciones",
                newName: "Fecha");

            migrationBuilder.RenameIndex(
                name: "IX_ProblemasResoluciones_TicketId",
                table: "ProblemasResoluciones",
                newName: "IX_ProblemasResoluciones_ProblemaId");

            migrationBuilder.AddColumn<string>(
                name: "Especialidad",
                table: "Tecnicos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TecnicoId",
                table: "ProblemasResoluciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "ProblemasResoluciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ProblemasResoluciones",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Problemas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EstadoProblemaId",
                table: "Problemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaResolucion",
                table: "Problemas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstadosProblemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosProblemas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EstadosProblemas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "abierto" },
                    { 2, "en-progreso" },
                    { 3, "resuelto" },
                    { 4, "cerrado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problemas_EstadoProblemaId",
                table: "Problemas",
                column: "EstadoProblemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problemas_EstadosProblemas_EstadoProblemaId",
                table: "Problemas",
                column: "EstadoProblemaId",
                principalTable: "EstadosProblemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemasResoluciones_Problemas_ProblemaId",
                table: "ProblemasResoluciones",
                column: "ProblemaId",
                principalTable: "Problemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemasResoluciones_Tecnicos_TecnicoId",
                table: "ProblemasResoluciones",
                column: "TecnicoId",
                principalTable: "Tecnicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
