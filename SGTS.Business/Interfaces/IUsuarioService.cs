using SGTS.Models.DTOs;

namespace SGTS.Business.Interfaces;

public interface IUsuarioService
{
    Task<PagedResult<UsuarioDTO>> Query(DataTableRequest request);

    Task<UsuarioDTO> ObtenerUsuarioPorId(int id);

    Task<IEnumerable<UsuarioDTO>> ObtenerPorNombre(string nombre);

    Task CrearUsuario(UsuarioDTO usuarioDto);

    Task ActualizarUsuario(UsuarioDTO usuarioDto);

    Task EliminarUsuario(int id);
}