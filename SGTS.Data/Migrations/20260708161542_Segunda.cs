using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGTS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adjuntos_Tickets_TicketIdTicket",
                table: "Adjuntos");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Tickets_TicketIdTicket",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_UsuarioIdUsuario",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Historiales_Tickets_TicketIdTicket",
                table: "Historiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Historiales_Usuarios_UsuarioIdUsuario",
                table: "Historiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Categorias_CategoriaIdCategoria",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Estados_EstadoIdEstado",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadIdPrioridad",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoIdDepartamento",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosRoles_Roles_RolIdRol",
                table: "UsuariosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosRoles_Usuarios_UsuarioIdUsuario",
                table: "UsuariosRoles");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosRoles_RolIdRol",
                table: "UsuariosRoles");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosRoles_UsuarioIdUsuario",
                table: "UsuariosRoles");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DepartamentoIdDepartamento",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CategoriaIdCategoria",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EstadoIdEstado",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PrioridadIdPrioridad",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Historiales_TicketIdTicket",
                table: "Historiales");

            migrationBuilder.DropIndex(
                name: "IX_Historiales_UsuarioIdUsuario",
                table: "Historiales");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_TicketIdTicket",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_UsuarioIdUsuario",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Adjuntos_TicketIdTicket",
                table: "Adjuntos");

            migrationBuilder.DropColumn(
                name: "RolIdRol",
                table: "UsuariosRoles");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "UsuariosRoles");

            migrationBuilder.DropColumn(
                name: "DepartamentoIdDepartamento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EstadoIdEstado",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PrioridadIdPrioridad",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketIdTicket",
                table: "Historiales");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Historiales");

            migrationBuilder.DropColumn(
                name: "TicketIdTicket",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "TicketIdTicket",
                table: "Adjuntos");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_IdRol",
                table: "UsuariosRoles",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdDepartamento",
                table: "Usuarios",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdCategoria",
                table: "Tickets",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdEstado",
                table: "Tickets",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdPrioridad",
                table: "Tickets",
                column: "IdPrioridad");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_IdTicket",
                table: "Historiales",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_IdUsuario",
                table: "Historiales",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdTicket",
                table: "Comentarios",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdUsuario",
                table: "Comentarios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Adjuntos_IdTicket",
                table: "Adjuntos",
                column: "IdTicket");

            migrationBuilder.AddForeignKey(
                name: "FK_Adjuntos_Tickets_IdTicket",
                table: "Adjuntos",
                column: "IdTicket",
                principalTable: "Tickets",
                principalColumn: "IdTicket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Tickets_IdTicket",
                table: "Comentarios",
                column: "IdTicket",
                principalTable: "Tickets",
                principalColumn: "IdTicket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_IdUsuario",
                table: "Comentarios",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Historiales_Tickets_IdTicket",
                table: "Historiales",
                column: "IdTicket",
                principalTable: "Tickets",
                principalColumn: "IdTicket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Historiales_Usuarios_IdUsuario",
                table: "Historiales",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Categorias_IdCategoria",
                table: "Tickets",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Estados_IdEstado",
                table: "Tickets",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prioridades_IdPrioridad",
                table: "Tickets",
                column: "IdPrioridad",
                principalTable: "Prioridades",
                principalColumn: "IdPrioridad",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Departamentos_IdDepartamento",
                table: "Usuarios",
                column: "IdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosRoles_Roles_IdRol",
                table: "UsuariosRoles",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosRoles_Usuarios_IdUsuario",
                table: "UsuariosRoles",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adjuntos_Tickets_IdTicket",
                table: "Adjuntos");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Tickets_IdTicket",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_IdUsuario",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Historiales_Tickets_IdTicket",
                table: "Historiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Historiales_Usuarios_IdUsuario",
                table: "Historiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Categorias_IdCategoria",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Estados_IdEstado",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prioridades_IdPrioridad",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Departamentos_IdDepartamento",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosRoles_Roles_IdRol",
                table: "UsuariosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosRoles_Usuarios_IdUsuario",
                table: "UsuariosRoles");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosRoles_IdRol",
                table: "UsuariosRoles");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdDepartamento",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_IdCategoria",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_IdEstado",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_IdPrioridad",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Historiales_IdTicket",
                table: "Historiales");

            migrationBuilder.DropIndex(
                name: "IX_Historiales_IdUsuario",
                table: "Historiales");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_IdTicket",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_IdUsuario",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Adjuntos_IdTicket",
                table: "Adjuntos");

            migrationBuilder.AddColumn<int>(
                name: "RolIdRol",
                table: "UsuariosRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "UsuariosRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoIdDepartamento",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoIdEstado",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrioridadIdPrioridad",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketIdTicket",
                table: "Historiales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Historiales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketIdTicket",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketIdTicket",
                table: "Adjuntos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_RolIdRol",
                table: "UsuariosRoles",
                column: "RolIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_UsuarioIdUsuario",
                table: "UsuariosRoles",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoIdDepartamento",
                table: "Usuarios",
                column: "DepartamentoIdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CategoriaIdCategoria",
                table: "Tickets",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EstadoIdEstado",
                table: "Tickets",
                column: "EstadoIdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PrioridadIdPrioridad",
                table: "Tickets",
                column: "PrioridadIdPrioridad");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_TicketIdTicket",
                table: "Historiales",
                column: "TicketIdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Historiales_UsuarioIdUsuario",
                table: "Historiales",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_TicketIdTicket",
                table: "Comentarios",
                column: "TicketIdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioIdUsuario",
                table: "Comentarios",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Adjuntos_TicketIdTicket",
                table: "Adjuntos",
                column: "TicketIdTicket");

            migrationBuilder.AddForeignKey(
                name: "FK_Adjuntos_Tickets_TicketIdTicket",
                table: "Adjuntos",
                column: "TicketIdTicket",
                principalTable: "Tickets",
                principalColumn: "IdTicket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Tickets_TicketIdTicket",
                table: "Comentarios",
                column: "TicketIdTicket",
                principalTable: "Tickets",
                principalColumn: "IdTicket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_UsuarioIdUsuario",
                table: "Comentarios",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Historiales_Tickets_TicketIdTicket",
                table: "Historiales",
                column: "TicketIdTicket",
                principalTable: "Tickets",
                principalColumn: "IdTicket",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Historiales_Usuarios_UsuarioIdUsuario",
                table: "Historiales",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Categorias_CategoriaIdCategoria",
                table: "Tickets",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Estados_EstadoIdEstado",
                table: "Tickets",
                column: "EstadoIdEstado",
                principalTable: "Estados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadIdPrioridad",
                table: "Tickets",
                column: "PrioridadIdPrioridad",
                principalTable: "Prioridades",
                principalColumn: "IdPrioridad",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoIdDepartamento",
                table: "Usuarios",
                column: "DepartamentoIdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosRoles_Roles_RolIdRol",
                table: "UsuariosRoles",
                column: "RolIdRol",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosRoles_Usuarios_UsuarioIdUsuario",
                table: "UsuariosRoles",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
