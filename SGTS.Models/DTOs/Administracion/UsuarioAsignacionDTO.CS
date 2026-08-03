namespace SGTS.Models.DTOs.Administracion;

public class UsuarioAsignacionDTO
{
    public int IdUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public int IdRol { get; set; }
    public string NombreRol { get; set; }
    public int IdDepartamento { get; set; }
    public string NombreDepartamento { get; set; }
}
