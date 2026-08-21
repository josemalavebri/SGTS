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

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );
    }
}