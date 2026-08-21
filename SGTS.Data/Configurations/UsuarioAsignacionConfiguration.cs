using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class UsuarioAsignacionConfiguration
    : IEntityTypeConfiguration<UsuarioAsignacion>
{
    public void Configure(EntityTypeBuilder<UsuarioAsignacion> builder)
    {
        builder.HasKey(ua => ua.IdUsuario);

        // Usuario 1:1 UsuarioAsignacion
        builder.HasOne(ua => ua.Usuario)
            .WithOne(u => u.UsuarioAsignacion)
            .HasForeignKey<UsuarioAsignacion>(ua => ua.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // Rol 1:N UsuarioAsignacion
        builder.HasOne(ua => ua.Rol)
            .WithMany(r => r.UsuarioAsignaciones)
            .HasForeignKey(ua => ua.IdRol)
            .OnDelete(DeleteBehavior.Restrict);

        // Departamento 1:N UsuarioAsignacion
        builder.HasOne(ua => ua.Departamento)
            .WithMany(d => d.UsuarioAsignaciones)
            .HasForeignKey(ua => ua.IdDepartamento)
            .OnDelete(DeleteBehavior.Restrict);
    }
}