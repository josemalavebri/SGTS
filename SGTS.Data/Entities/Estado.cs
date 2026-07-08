namespace SGTS.Data.Entities;

public class Estado
{
    public int IdEstado { get; set; }
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}   