using Microsoft.EntityFrameworkCore;
using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;

namespace SGTS.Data.Repositories;

public class UsuarioAsignacionRepository : IUsuarioAsignacionRepository
{
    private readonly AppDbContext _context;

    public UsuarioAsignacionRepository(AppDbContext context)
    {
        this._context = context;
    }

    public async Task<(IEnumerable<UsuarioAsignacion>, int, int)> GetAllAsync()
    {
        //Todo el sistema de query service cambio
        return (null, 0, 0);
    }

    public async Task<UsuarioAsignacion?> GetByIdAsync(int idUsuario)
    {
        return await _context.UsuariosAsignaciones
            .AsNoTracking()
            .Include(r => r.Departamento)
            .Include(r => r.Rol)
            .Include(r => r.Usuario)
            .FirstOrDefaultAsync(ur =>
                ur.IdUsuario == idUsuario);
    }

    public async Task<bool> AddAsync(UsuarioAsignacion entity)
    {
        await _context.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(UsuarioAsignacion entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(UsuarioAsignacion entity)
    {
        _context.UsuariosAsignaciones.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}