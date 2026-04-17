using System.ComponentModel.DataAnnotations;

namespace SGTS.Data.Entities;

public class Prioridad
{
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public string Nombre { get; set; }


}