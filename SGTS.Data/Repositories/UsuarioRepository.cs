using Microsoft.EntityFrameworkCore;
using SGTS.Data.Context;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Data.Const;
using SGTS.Data.Services;
using SGTS.Models.DTOs;
using SGTS.Data.Exceptions;

namespace SGTS.Data.Repositories;

public class UsuarioRepository(AppDbContext context, DataTableQueryService queryService) : IUsuarioRepository
{
    private readonly AppDbContext _context = context;
    private readonly DataTableQueryService _queryService = queryService;

    public async Task<PagedResult<Usuario>> GetPagedAsync(DataTableRequest request)
    {
        try
        {
            var query = _context.Usuarios
            .Where(p => p.Activo);

            var (items, totalRecords, totalRecordsFiltered) = await _queryService.QueryAsync(
                query,
                request,
                search => x =>
                    x.Nombre.Contains(search) ||
                    x.Correo.Contains(search)
            );

            return new PagedResult<Usuario>
            {
                Items = items.ToList(),
                TotalRecords = totalRecords,
                TotalRecordsFiltered = totalRecordsFiltered
            };
        }
        catch (Exception ex)
        {
            throw new PersistenceException(DataMessages.ERROR_OBTENER, ex);
        }
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .AnyAsync(u => u.Correo == email);
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (Exception ex)
        {
            throw new PersistenceException(DataMessages.ERROR_OBTENER, ex);
        }
    }

    public async Task<IEnumerable<Usuario>> GetByNameAsync(string nombre)
    {
        try
        {
            return await _context.Usuarios
                .AsNoTracking()
                .Where(u => u.Activo && u.Nombre.Contains(nombre))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(DataMessages.ERROR_CONSULTA_LISTA, ex);
        }
    }

    public async Task AddAsync(Usuario usuario)
    {
        try
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(DataMessages.ERROR_CREAR, ex);
        }
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        try
        {
            _context.Entry(usuario).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(DataMessages.ERROR_ACTUALIZAR, ex);
        }
    }

    public async Task DeleteAsync(Usuario usuario)
    {
        try
        {
            usuario.Activo = false;

            _context.Entry(usuario).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(DataMessages.ERROR_ELIMINAR, ex);
        }
    }
}