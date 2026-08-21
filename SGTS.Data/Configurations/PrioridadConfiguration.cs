using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class PrioridadConfiguration : IEntityTypeConfiguration<Prioridad>
{
    public void Configure(EntityTypeBuilder<Prioridad> builder)
    {
        builder.HasKey(p => p.IdPrioridad);

        builder.HasData(
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
    }
}