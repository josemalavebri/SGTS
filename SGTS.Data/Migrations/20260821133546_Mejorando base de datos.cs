using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGTS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mejorandobasededatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_TecnicoAsignadoId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosAsignaciones_Departamentos_IdDepartamento",
                table: "UsuariosAsignaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosAsignaciones_Roles_IdRol",
                table: "UsuariosAsignaciones");

            migrationBuilder.DropTable(
                name: "Historiales");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TecnicoAsignadoId",
                table: "Tickets",
                newName: "UsuarioIdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TecnicoAsignadoId",
                table: "Tickets",
                newName: "IX_Tickets_UsuarioIdUsuario");

            migrationBuilder.AddColumn<bool>(
                name: "EsInicial",
                table: "Comentarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AsignacionesTickets",
                columns: table => new
                {
                    IdAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTicket = table.Column<int>(type: "int", nullable: false),
                    IdTecnico = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDesasignacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionesTickets", x => x.IdAsignacion);
                    table.ForeignKey(
                        name: "FK_AsignacionesTickets_Tickets_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "Tickets",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionesTickets_Usuarios_IdTecnico",
                        column: x => x.IdTecnico,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TiposActividadTicket",
                columns: table => new
                {
                    IdTipoActividad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposActividadTicket", x => x.IdTipoActividad);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesTickets",
                columns: table => new
                {
                    IdActividad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTicket = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipoActividad = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesTickets", x => x.IdActividad);
                    table.ForeignKey(
                        name: "FK_ActividadesTickets_Tickets_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "Tickets",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadesTickets_TiposActividadTicket_IdTipoActividad",
                        column: x => x.IdTipoActividad,
                        principalTable: "TiposActividadTicket",
                        principalColumn: "IdTipoActividad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActividadesTickets_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TiposActividadTicket",
                columns: new[] { "IdTipoActividad", "Nombre" },
                values: new object[,]
                {
                    { 1, "creacion" },
                    { 2, "comentario" },
                    { 3, "asignacion" },
                    { 4, "reasignacion" },
                    { 5, "cambio-estado" },
                    { 6, "cambio-prioridad" },
                    { 7, "cambio-categoria" },
                    { 8, "cierre" },
                    { 9, "reapertura" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesTickets_IdTicket",
                table: "ActividadesTickets",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesTickets_IdTipoActividad",
                table: "ActividadesTickets",
                column: "IdTipoActividad");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesTickets_IdUsuario",
                table: "ActividadesTickets",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesTickets_IdTecnico",
                table: "AsignacionesTickets",
                column: "IdTecnico");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesTickets_IdTicket",
                table: "AsignacionesTickets",
                column: "IdTicket");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioIdUsuario",
                table: "Tickets",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosAsignaciones_Departamentos_IdDepartamento",
                table: "UsuariosAsignaciones",
                column: "IdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosAsignaciones_Roles_IdRol",
                table: "UsuariosAsignaciones",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_UsuarioIdUsuario",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosAsignaciones_Departamentos_IdDepartamento",
                table: "UsuariosAsignaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosAsignaciones_Roles_IdRol",
                table: "UsuariosAsignaciones");

            migrationBuilder.DropTable(
                name: "ActividadesTickets");

            migrationBuilder.DropTable(
                name: "AsignacionesTickets");

            migrationBuilder.DropTable(
                name: "TiposActividadTicket");

            migrationBuilder.DropColumn(
                name: "EsInicial",
                table: "Comentarios");

            migrationBuilder.RenameColumn(
                name: "UsuarioIdUsuario",
                table: "Tickets",
                newName: "TecnicoAsignadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UsuarioIdUsuario",
                table: "Tickets",
                newName: "IX_Tickets_TecnicoAsignadoId");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Tickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Historiales",
                columns: table => new
                {
                    IdHistorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTicket = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiales", x => x.IdHistorial);
                    table.ForeignKey(
                        name: "FK_Historiales_Tickets_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "Tickets",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historiales_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_IdTicket",
                table: "Historiales",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_IdUsuario",
                table: "Historiales",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_TecnicoAsignadoId",
                table: "Tickets",
                column: "TecnicoAsignadoId",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);

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
    }
}
