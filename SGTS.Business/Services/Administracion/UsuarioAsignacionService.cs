using SGTS.Business.Interfaces;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;
using SGTS.Models.DTOs.Administracion;

namespace SGTS.Business.Services.Administracion;

public class UsuarioAsignacionService : IUsuarioAsignacionService
{
    private readonly IUsuarioAsignacionRepository _repository;

    public UsuarioAsignacionService(IUsuarioAsignacionRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<UsuarioAsignacionDTO>> GetAllAsync(DataTableRequestDTO dto)
    {
        var (usuariosRoles, totalRecords, filteredRecords) =
            await _repository.GetAllAsync(dto);

        var items = usuariosRoles.Select(ur => MapToDTO(ur));

        return new PagedResult<UsuarioAsignacionDTO>
        {
            Items = items,
            TotalRecords = totalRecords,
            TotalRecordsFiltered = filteredRecords
        };
    }

    public async Task<UsuarioAsignacionDTO?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
        {
            return null;
        }
        return MapToDTO(entity);
    }

    public async Task<bool> CreateAsync(UsuarioAsignacionDTO dto)
    {
        var entity = new UsuarioAsignacion
        {
            IdUsuario = dto.IdUsuario,
            IdRol = dto.IdRol,
            IdDepartamento = dto.IdDepartamento
        };

        return await _repository.AddAsync(entity);
    }

    public async Task<bool> UpdateAsync(UsuarioAsignacionDTO dto)
    {
        var entity = await _repository.GetByIdAsync(dto.IdUsuario);

        if (entity == null)
        {
            throw new KeyNotFoundException("La asignación usuario-rol no existe.");
        }

        entity.IdRol = dto.IdRol;
        entity.IdDepartamento = dto.IdDepartamento;

        return await _repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity is null)
        {
            throw new KeyNotFoundException(
                "La asignación usuario-rol no existe.");
        }

        return await _repository.DeleteAsync(entity);
    }

    private static UsuarioAsignacionDTO MapToDTO(UsuarioAsignacion entity)
    {
        return new UsuarioAsignacionDTO
        {
            IdUsuario = entity.IdUsuario,
            IdRol = entity.IdRol ?? 0,
            IdDepartamento = entity.IdDepartamento ?? 0,
            NombreDepartamento = entity.Departamento?.Nombre ?? string.Empty,
            NombreRol = entity.Rol?.Nombre ?? string.Empty,
            NombreUsuario = entity.Usuario?.Nombre ?? string.Empty
        };
    }

    public Task<object> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
