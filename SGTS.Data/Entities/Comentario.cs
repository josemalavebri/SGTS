namespace SGTS.Data.Entities;

public class Comentario
{
    public int IdComentario { get; set; }

    public int IdTicket { get; set; }

    public int IdUsuario { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}