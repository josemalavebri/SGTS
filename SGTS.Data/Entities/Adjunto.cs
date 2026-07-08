namespace SGTS.Data.Entities;

public class Adjunto
{
    public int IdAdjunto { get; set; }

    public int IdTicket { get; set; }

    public string NombreArchivo { get; set; } = null!;

    public string RutaArchivo { get; set; } = null!;

    public string? Extension { get; set; }

    public long? Tamano { get; set; }

    public DateTime FechaCarga { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}