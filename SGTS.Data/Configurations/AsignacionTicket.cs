using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class AsignacionTicketConfiguration
    : IEntityTypeConfiguration<AsignacionTicket>
{
    public void Configure(EntityTypeBuilder<AsignacionTicket> builder)
    {
        builder.HasKey(a => a.IdAsignacion);

        // Ticket 1:N AsignacionTicket
        builder.HasOne(a => a.Ticket)
            .WithMany(t => t.Asignaciones)
            .HasForeignKey(a => a.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario 1:N AsignacionTicket
        // Usuario que representa al técnico asignado.
        builder.HasOne(a => a.Tecnico)
            .WithMany(u => u.AsignacionesTickets)
            .HasForeignKey(a => a.IdTecnico)
            .OnDelete(DeleteBehavior.Restrict);
    }
}