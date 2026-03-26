using System.ComponentModel.DataAnnotations;

namespace SGTS.Models.Entities;

public class Tecnico
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nombre { get; set; }

    [Required, MaxLength(15)]
    public string Telefono { get; set; }

    public bool Activo { get; set; }

    [MaxLength(50)]
    public string Especialidad { get; set; } // Opcional
}