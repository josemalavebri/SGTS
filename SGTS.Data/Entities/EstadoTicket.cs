using System.ComponentModel.DataAnnotations;

namespace SGTS.Data.Entities;

public class EstadoTicket
{
    public int Id { get; set; }

    [Required, MaxLength(15)]

    public string Nombre { get; set; }
}