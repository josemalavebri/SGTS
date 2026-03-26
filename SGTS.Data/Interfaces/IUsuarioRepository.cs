using SGTS.Models.Entities;

namespace SGTS.Data.Interfaces;

public interface IUsuarioRepository
{
    IEnumerable<Usuario> ObtenerTodos();
    Usuario ObtenerPorId(int id);
}