using Microsoft.EntityFrameworkCore;
using SGTS.Models.Entities;

namespace SGTS.Data.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Problema> Problemas { get; set; }
    public DbSet<Tecnico> Tecnicos { get; set; }
    public DbSet<EstadoProblema> EstadosProblemas { get; set; }
    public DbSet<ProblemaResolucion> ProblemasResoluciones { get; set; }
    
}