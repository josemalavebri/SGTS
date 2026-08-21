using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class TipoActividadTicketConfiguration
    : IEntityTypeConfiguration<TipoActividadTicket>
{
    public void Configure(EntityTypeBuilder<TipoActividadTicket> builder)
    {
        builder.HasKey(t => t.IdTipoActividad);

        builder.HasData(
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