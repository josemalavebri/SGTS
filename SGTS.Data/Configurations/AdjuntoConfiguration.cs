using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class AdjuntoConfiguration : IEntityTypeConfiguration<Adjunto>
{
    public void Configure(EntityTypeBuilder<Adjunto> builder)
    {
        builder.HasKey(a => a.IdAdjunto);

        // Ticket 1:N Adjunto
        builder.HasOne(a => a.Ticket)
            .WithMany(t => t.Adjuntos)
            .HasForeignKey(a => a.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);
    }
}