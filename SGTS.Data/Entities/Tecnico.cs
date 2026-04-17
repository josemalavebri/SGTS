using System.ComponentModel.DataAnnotations;

namespace SGTS.Data.Entities;

public class Tecnico
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nombre { get; set; }

    [Required, MaxLength(15)]
    public string Telefono { get; set; }

    public bool Activo { get; set; }

}