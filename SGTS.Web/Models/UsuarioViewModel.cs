using System.ComponentModel.DataAnnotations;

namespace SGTS.Web.Models;

public class UsuarioViewModel
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    public string Correo { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [Phone(ErrorMessage = "Número de teléfono inválido")]
    public string Telefono { get; set; }
}