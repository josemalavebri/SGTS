using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        // ============================================================
        // CLAVE PRIMARIA
        // ============================================================

        builder.HasKey(t => t.IdTicket);


        // ============================================================
        // USUARIO - TICKET
        // ============================================================

        // Un usuario puede crear muchos tickets.
        builder.HasOne(t => t.Usuario)
            .WithMany(u => u.TicketsCreados)
            .HasForeignKey(t => t.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);


        // ============================================================
        // CATEGORIA - TICKET
        // ============================================================

        // Una categoría puede tener muchos tickets.
        builder.HasOne(t => t.Categoria)
            .WithMany(c => c.Tickets)
            .HasForeignKey(t => t.IdCategoria)
            .OnDelete(DeleteBehavior.Restrict);


        // ============================================================
        // PRIORIDAD - TICKET
        // ============================================================

        // Una prioridad puede tener muchos tickets.
        builder.HasOne(t => t.Prioridad)
            .WithMany(p => p.Tickets)
            .HasForeignKey(t => t.IdPrioridad)
            .OnDelete(DeleteBehavior.Restrict);


        // ============================================================
        // ESTADO - TICKET
        // ============================================================

        // Un estado puede tener muchos tickets.
        builder.HasOne(t => t.Estado)
            .WithMany(e => e.Tickets)
            .HasForeignKey(t => t.IdEstado)
            .OnDelete(DeleteBehavior.Restrict);
    }
}