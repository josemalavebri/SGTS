using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class ActividadTicketConfiguration
    : IEntityTypeConfiguration<ActividadTicket>
{
    public void Configure(EntityTypeBuilder<ActividadTicket> builder)
    {
        builder.HasKey(a => a.IdActividad);

        // Ticket 1:N ActividadTicket
        builder.HasOne(a => a.Ticket)
            .WithMany(t => t.Actividades)
            .HasForeignKey(a => a.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario 1:N ActividadTicket
        // Usuario que produjo la actividad.
        builder.HasOne(a => a.Usuario)
            .WithMany(u => u.ActividadesTickets)
            .HasForeignKey(a => a.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);

        // TipoActividadTicket 1:N ActividadTicket
        builder.HasOne(a => a.TipoActividad)
            .WithMany(t => t.Actividades)
            .HasForeignKey(a => a.IdTipoActividad)
            .OnDelete(DeleteBehavior.Restrict);
    }
}