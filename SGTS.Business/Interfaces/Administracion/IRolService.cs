
using SGTS.Data.Entities.Administracion;
using SGTS.Models.DTOs;

namespace SGTS.Business.Interfaces.Administracion;

public interface IRolService
{
    Task<IEnumerable<RolDTO>> GetAllRolesAsync();
}
