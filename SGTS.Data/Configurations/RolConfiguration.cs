using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.HasKey(r => r.IdRol);

        builder.HasData(
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
    }
}