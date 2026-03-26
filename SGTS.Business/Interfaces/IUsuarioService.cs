using SGTS.Models.DTOs;

namespace SGTS.Business.Interfaces;

public interface IUsuarioService
{
    IEnumerable<UsuarioDTO> ObtenerUsuarios();
    UsuarioDTO ObtenerUsuarioPorId(int id);
}