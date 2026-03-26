using System.ComponentModel.DataAnnotations;

namespace SGTS.Models.Entities;

public class Prioridad
{
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public string Nivel { get; set; }  // Ej: Baja, Media, Alta
}