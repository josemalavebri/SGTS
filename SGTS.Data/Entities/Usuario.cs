using System.ComponentModel.DataAnnotations;

namespace SGTS.Data.Entities;

public class Usuario
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nombre { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    public string Correo { get; set; }

    [Required, MaxLength(15)]
    public string Telefono { get; set; }
    public bool Activo { get; set; }
}