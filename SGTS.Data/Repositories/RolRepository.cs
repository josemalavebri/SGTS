using Microsoft.EntityFrameworkCore;
using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Entities.Administracion;
using SGTS.Data.Interfaces.Administracion;
using SGTS.Models.DTOs;

namespace SGTS.Data.Repositories;

public class RolRepository : IRolRepository
{
    private AppDbContext _appDbContext { get; }

    public RolRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Rol>> GetAllRolesAsync()
    {
        return await _appDbContext.Roles.AsNoTracking().ToListAsync();
    }
}