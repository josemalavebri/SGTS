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
    public DbSet<Historial> Historiales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Departamento>()
            .HasKey(d => d.IdDepartamento);

        modelBuilder.Entity<Historial>()
            .HasKey(d => d.IdHistorial);

        modelBuilder.Entity<Ticket>()
            .HasKey(d => d.IdTicket);

        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.IdUsuario);

        modelBuilder.Entity<Rol>()
            .HasKey(r => r.IdRol);

        modelBuilder.Entity<Prioridad>()
            .HasKey(p => p.IdPrioridad);

        modelBuilder.Entity<Estado>()
            .HasKey(e => e.IdEstado);

        modelBuilder.Entity<UsuarioAsignacion>()
            .HasKey(x => x.IdUsuario);

        modelBuilder.Entity<Categoria>()
            .HasKey(c => c.IdCategoria);

        modelBuilder.Entity<Comentario>()
            .HasKey(c => c.IdComentario);

        modelBuilder.Entity<Adjunto>()
            .HasKey(a => a.IdAdjunto);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Usuario)
            .WithMany(u => u.TicketsCreados)
            .HasForeignKey(t => t.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.TecnicoAsignado)
            .WithMany(u => u.TicketsAsignados)
            .HasForeignKey(t => t.TecnicoAsignadoId)
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

        // Ticket 1:N Adjunto
        modelBuilder.Entity<Adjunto>()
            .HasOne(a => a.Ticket)
            .WithMany(t => t.Adjuntos)
            .HasForeignKey(a => a.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);

        // Ticket 1:N Historial
        modelBuilder.Entity<Historial>()
            .HasOne(h => h.Ticket)
            .WithMany(t => t.Historiales)
            .HasForeignKey(h => h.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario 1:N Historial
        modelBuilder.Entity<Historial>()
            .HasOne(h => h.Usuario)
            .WithMany(u => u.Historiales)
            .HasForeignKey(h => h.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UsuarioAsignacion>()
            .HasOne(ua => ua.Usuario)
            .WithOne(u => u.UsuarioAsignacion)
            .HasForeignKey<UsuarioAsignacion>(ua => ua.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UsuarioAsignacion>()
            .HasOne(ua => ua.Rol)
            .WithMany(r => r.UsuarioAsignaciones)
            .HasForeignKey(ua => ua.IdRol);

        modelBuilder.Entity<UsuarioAsignacion>()
            .HasOne(ua => ua.Departamento)
            .WithMany(d => d.UsuarioAsignaciones)
            .HasForeignKey(ua => ua.IdDepartamento);

        // Estados iniciales
        modelBuilder.Entity<Estado>().HasData(
            new Estado { IdEstado = 1, Nombre = "abierto" },
            new Estado { IdEstado = 2, Nombre = "en-progreso" },
            new Estado { IdEstado = 3, Nombre = "resuelto" },
            new Estado { IdEstado = 4, Nombre = "cerrado" }
        );

        // Prioridades iniciales
        modelBuilder.Entity<Prioridad>().HasData(
            new Prioridad { IdPrioridad = 1, Nombre = "baja" },
            new Prioridad { IdPrioridad = 2, Nombre = "media" },
            new Prioridad { IdPrioridad = 3, Nombre = "alta" }
        );

        // Roles iniciales
        modelBuilder.Entity<Rol>().HasData(
            new Rol { IdRol = 1, Nombre = "administrador" },
            new Rol { IdRol = 2, Nombre = "tecnico" },
            new Rol { IdRol = 3, Nombre = "empleado" },
            new Rol { IdRol = 4, Nombre = "supervisor" }
        );
    }
}