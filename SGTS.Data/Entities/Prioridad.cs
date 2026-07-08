namespace SGTS.Data.Entities;

public class Prioridad
{
    public int IdPrioridad { get; set; }
    public string Nombre { get; set; } = null!;
    public int Nivel { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}