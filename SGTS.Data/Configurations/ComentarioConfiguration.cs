using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGTS.Data.Entities;

namespace SGTS.Data.Configurations;

public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.HasKey(c => c.IdComentario);

        // Ticket 1:N Comentario
        builder.HasOne(c => c.Ticket)
            .WithMany(t => t.Comentarios)
            .HasForeignKey(c => c.IdTicket)
            .OnDelete(DeleteBehavior.Cascade);

        // Usuario 1:N Comentario
        builder.HasOne(c => c.Usuario)
            .WithMany(u => u.Comentarios)
            .HasForeignKey(c => c.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);
    }
}