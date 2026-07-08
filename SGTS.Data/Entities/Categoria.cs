namespace SGTS.Data.Entities;

public class Categoria
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}