using System.ComponentModel.DataAnnotations;

namespace SGTS.Data.Entities;

public class Ticket
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public int PrioridadId { get; set; }
    public Prioridad Prioridad { get; set; }
    public int? ImagenId { get; set; }
    public Imagen? Imagen { get; set; }
    public string Descripcion { get; set; }
    [Required, MaxLength(500)]
    public DateTime FechaReporte { get; set; }
    public bool Activo { get; set; }

}