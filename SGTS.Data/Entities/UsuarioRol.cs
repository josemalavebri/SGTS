namespace SGTS.Data.Entities;

public class UsuarioRol
{
    public int IdUsuario { get; set; }
    public int IdRol { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
    public virtual Rol Rol { get; set; } = null!;
}