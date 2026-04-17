using Microsoft.EntityFrameworkCore;
using SGTS.Data.Entities;

namespace SGTS.Data.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EstadoTicket>().HasData(
            new EstadoTicket { Id = 1, Nombre = "abierto" },
            new EstadoTicket { Id = 2, Nombre = "en-progreso" },
            new EstadoTicket { Id = 3, Nombre = "resuelto" },
            new EstadoTicket { Id = 4, Nombre = "cerrado" }
        );

        modelBuilder.Entity<Prioridad>().HasData(
            new Prioridad { Id = 1, Nombre = "baja" },
            new Prioridad { Id = 2, Nombre = "media" },
            new Prioridad { Id = 3, Nombre = "alta" }
        );

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Ticket> Problemas { get; set; }
    public DbSet<Tecnico> Tecnicos { get; set; }
    public DbSet<EstadoTicket> Estados { get; set; }
    public DbSet<TicketHistorialEstado> ProblemasResoluciones { get; set; }
    public DbSet<Imagen> Imagenes { get; set; }
}