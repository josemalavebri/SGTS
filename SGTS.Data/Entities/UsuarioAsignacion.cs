namespace SGTS.Data.Entities;

public class UsuarioAsignacion
{
    public int IdUsuario { get; set; }
    public int? IdRol { get; set; }
    public int? IdDepartamento { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
    public virtual Rol? Rol { get; set; }
    public virtual Departamento? Departamento { get; set; }
}