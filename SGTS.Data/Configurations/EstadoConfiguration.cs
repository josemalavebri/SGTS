using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.HasKey(e => e.IdEstado);

        builder.HasData(
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
    }
}