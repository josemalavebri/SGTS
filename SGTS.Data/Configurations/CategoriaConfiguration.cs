using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class CategoriaConfiguration
    : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.IdCategoria);

        builder.Property(c => c.Nombre)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new Categoria
            {
                IdCategoria = 1,
                Nombre = "Hardware"
            },
            new Categoria
            {
                IdCategoria = 2,
                Nombre = "Software"
            },
            new Categoria
            {
                IdCategoria = 3,
                Nombre = "Redes y Conectividad"
            },
            new Categoria
            {
                IdCategoria = 4,
                Nombre = "Sistemas Operativos"
            },
            new Categoria
            {
                IdCategoria = 5,
                Nombre = "Accesos y Credenciales"
            },
            new Categoria
            {
                IdCategoria = 6,
                Nombre = "Impresoras y Periféricos"
            },
            new Categoria
            {
                IdCategoria = 7,
                Nombre = "Correo Electrónico"
            },
            new Categoria
            {
                IdCategoria = 8,
                Nombre = "Aplicaciones Institucionales"
            },
            new Categoria
            {
                IdCategoria = 9,
                Nombre = "Soporte al Usuario"
            },
            new Categoria
            {
                IdCategoria = 10,
                Nombre = "Otros"
            }
        );
    }
}