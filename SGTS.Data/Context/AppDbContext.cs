using Microsoft.EntityFrameworkCore;
using SGTS.Data.Entities;

namespace SGTS.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<UsuarioAsignacion> UsuariosAsignaciones { get; set; }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Prioridad> Prioridades { get; set; }
    public DbSet<Estado> Estados { get; set; }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<Adjunto> Adjuntos { get; set; }

    public DbSet<AsignacionTicket> AsignacionesTickets { get; set; }

    public DbSet<ActividadTicket> ActividadesTickets { get; set; }
    public DbSet<TipoActividadTicket> TiposActividadTicket { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // ============================================================
        // CLAVES PRIMARIAS
        // ============================================================

        modelBuilder.Entity<Departamento>()
            .HasKey(d => d.IdDepartamento);

        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.IdUsuario);

        modelBuilder.Entity<Rol>()
            .HasKey(r => r.IdRol);

        modelBuilder.Entity<UsuarioAsignacion>()
            .HasKey(ua => ua.IdUsuario);

        modelBuilder.Entity<Categoria>()
            .HasKey(c => c.IdCategoria);

        modelBuilder.Entity<Prioridad>()
            .HasKey(p => p.IdPrioridad);

        modelBuilder.Entity<Estado>()
            .HasKey(e => e.IdEstado);

        modelBuilder.Entity<Ticket>()
            .HasKey(t => t.IdTicket);

        modelBuilder.Entity<Comentario>()
            .HasKey(c => c.IdComentario);

        modelBuilder.Entity<Adjunto>()
            .HasKey(a => a.IdAdjunto);

        modelBuilder.Entity<AsignacionTicket>()
            .HasKey(a => a.IdAsignacion);

        modelBuilder.Entity<ActividadTicket>()
            .HasKey(a => a.IdActividad);

        modelBuilder.Entity<TipoActividadTicket>()
            .HasKey(t => t.IdTipoActividad);




        // ============================================================
        // TICKET
        // ============================================================

        // Usuario 1:N Ticket
        // Un usuario puede crear muchos tickets.
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Usuario)
            .WithMany(u => u.TicketsCreados)
            .HasForeignKey(t => t.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);

        // Categoria 1:N Ticket
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Categoria)
            .WithMany(c => c.Tickets)
            .HasForeignKey(t => t.IdCategoria)
            .OnDelete(DeleteBehavior.Restrict);

        // Prioridad 1:N Ticket
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Prioridad)
            .WithMany(p => p.Tickets)
            .HasForeignKey(t => t.IdPrioridad)
            .OnDelete(DeleteBehavior.Restrict);

        // Estado 1:N Ticket
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Estado)
            .WithMany(e => e.Tickets)
            .HasForeignKey(t => t.IdEstado)
            .OnDelete(DeleteBehavior.Restrict);


        // ============================================================
        // COMENTARIOS
        // ============================================================

        // Ticket 1:N Comentario
        modelBuilder.Entity<Comentario>()
            .HasOne(c => c.Ticket)
            .WithMany(t => t.Comentarios)
            .HasForeignKey(c => c.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario 1:N Comentario
        modelBuilder.Entity<Comentario>()
            .HasOne(c => c.Usuario)
            .WithMany(u => u.Comentarios)
            .HasForeignKey(c => c.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);


        // ============================================================
        // ADJUNTOS
        // ============================================================

        // Ticket 1:N Adjunto
        modelBuilder.Entity<Adjunto>()
            .HasOne(a => a.Ticket)
            .WithMany(t => t.Adjuntos)
            .HasForeignKey(a => a.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);


        // ============================================================
        // ASIGNACIONES DE TICKETS
        // ============================================================

        // Ticket 1:N AsignacionTicket
        modelBuilder.Entity<AsignacionTicket>()
            .HasOne(a => a.Ticket)
            .WithMany(t => t.Asignaciones)
            .HasForeignKey(a => a.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario 1:N AsignacionTicket
        // El usuario representa al técnico asignado.
        modelBuilder.Entity<AsignacionTicket>()
    .HasOne(a => a.Tecnico)
    .WithMany(u => u.AsignacionesTickets)
    .HasForeignKey(a => a.IdTecnico)
    .OnDelete(DeleteBehavior.Restrict);


        // ============================================================
        // ACTIVIDAD DEL TICKET
        // ============================================================

        // Ticket 1:N ActividadTicket
        modelBuilder.Entity<ActividadTicket>()
            .HasOne(a => a.Ticket)
            .WithMany(t => t.Actividades)
            .HasForeignKey(a => a.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario 1:N ActividadTicket
        // Usuario que produjo la actividad.
        modelBuilder.Entity<ActividadTicket>()
            .HasOne(a => a.Usuario)
            .WithMany(u => u.ActividadesTickets)
            .HasForeignKey(a => a.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);

        // TipoActividadTicket 1:N ActividadTicket
        modelBuilder.Entity<ActividadTicket>()
            .HasOne(a => a.TipoActividad)
            .WithMany(t => t.Actividades)
            .HasForeignKey(a => a.IdTipoActividad)
            .OnDelete(DeleteBehavior.Restrict);


        // ============================================================
        // AUDITORÍA
        // ============================================================




        // ============================================================
        // USUARIO - ASIGNACIÓN
        // ============================================================

        // Usuario 1:1 UsuarioAsignacion
        modelBuilder.Entity<UsuarioAsignacion>()
            .HasOne(ua => ua.Usuario)
            .WithOne(u => u.UsuarioAsignacion)
            .HasForeignKey<UsuarioAsignacion>(ua => ua.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // Rol 1:N UsuarioAsignacion
        modelBuilder.Entity<UsuarioAsignacion>()
            .HasOne(ua => ua.Rol)
            .WithMany(r => r.UsuarioAsignaciones)
            .HasForeignKey(ua => ua.IdRol)
            .OnDelete(DeleteBehavior.Restrict);

        // Departamento 1:N UsuarioAsignacion
        modelBuilder.Entity<UsuarioAsignacion>()
            .HasOne(ua => ua.Departamento)
            .WithMany(d => d.UsuarioAsignaciones)
            .HasForeignKey(ua => ua.IdDepartamento)
            .OnDelete(DeleteBehavior.Restrict);


        // ============================================================
        // DATOS INICIALES
        // ============================================================

        modelBuilder.Entity<Estado>().HasData(
            new Estado
            {
                IdEstado = 1,
                Nombre = "abierto"
            },
            new Estado
            {
                IdEstado = 2,
                Nombre = "en-progreso"
            },
            new Estado
            {
                IdEstado = 3,
                Nombre = "resuelto"
            },
            new Estado
            {
                IdEstado = 4,
                Nombre = "cerrado"
            }
        );


        modelBuilder.Entity<Prioridad>().HasData(
            new Prioridad
            {
                IdPrioridad = 1,
                Nombre = "baja"
            },
            new Prioridad
            {
                IdPrioridad = 2,
                Nombre = "media"
            },
            new Prioridad
            {
                IdPrioridad = 3,
                Nombre = "alta"
            }
        );


        modelBuilder.Entity<Rol>().HasData(
            new Rol
            {
                IdRol = 1,
                Nombre = "administrador"
            },
            new Rol
            {
                IdRol = 2,
                Nombre = "tecnico"
            },
            new Rol
            {
                IdRol = 3,
                Nombre = "empleado"
            },
            new Rol
            {
                IdRol = 4,
                Nombre = "supervisor"
            }
        );


        // ============================================================
        // TIPOS DE ACTIVIDAD
        // ============================================================

        modelBuilder.Entity<TipoActividadTicket>().HasData(
            new TipoActividadTicket
            {
                IdTipoActividad = 1,
                Nombre = "creacion"
            },
            new TipoActividadTicket
            {
                IdTipoActividad = 2,
                Nombre = "comentario"
            },
            new TipoActividadTicket
            {
                IdTipoActividad = 3,
                Nombre = "asignacion"
            },
            new TipoActividadTicket
            {
                IdTipoActividad = 4,
                Nombre = "reasignacion"
            },
            new TipoActividadTicket
            {
                IdTipoActividad = 5,
                Nombre = "cambio-estado"
            },
            new TipoActividadTicket
            {
                IdTipoActividad = 6,
                Nombre = "cambio-prioridad"
            },
            new TipoActividadTicket
            {
                IdTipoActividad = 7,
                Nombre = "cambio-categoria"
            },
            new TipoActividadTicket
            {
                IdTipoActividad = 8,
                Nombre = "cierre"
            },
            new TipoActividadTicket
            {
                IdTipoActividad = 9,
                Nombre = "reapertura"
            }
        );

    }
}