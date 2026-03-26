using System.ComponentModel.DataAnnotations;

namespace SGTS.Models.Entities;

public class EstadoProblema
{
    public int Id { get; set; }

    [Required, MaxLength(15)]

    public string Nombre { get; set; }
}