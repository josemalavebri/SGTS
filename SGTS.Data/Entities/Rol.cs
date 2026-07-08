namespace SGTS.Data.Entities;

public class Rol
{
    public int IdRol { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
}
