using SGTS.Data.Entities;

namespace SGTS.Data.Interfaces.Administracion;

public interface IRolRepository
{
    Task<IEnumerable<Rol>> GetAllRolesAsync();
}
