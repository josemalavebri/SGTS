using SGTS.Business.Interfaces.Administracion;
using SGTS.Data.Entities.Administracion;
using SGTS.Data.Interfaces.Administracion;

namespace SGTS.Business.Services.Administracion;

public class RolService : IRolService
{
    private readonly IRolRepository _repository;

    public RolService(IRolRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RolDTO>> GetAllRolesAsync()
    {
        var roles = await _repository.GetAllRolesAsync();
        return roles.Select(r => new RolDTO
        {
            IdRol = r.IdRol,
            Nombre = r.Nombre
        });
    }
}

