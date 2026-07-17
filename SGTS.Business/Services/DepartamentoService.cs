using SGTS.Business.Interfaces;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;

namespace SGTS.Business.Services;

public class DepartamentoService : IDepartamentoService
{
    private readonly IDepartamentosRepository _departamentosRepository;

    public DepartamentoService(IDepartamentosRepository departamentosRepository)
    {
        _departamentosRepository = departamentosRepository;
    }

    public async Task<PagedResult<DepartamentoDTO>> GetAllDepartamentosAsync(DataTableRequestDTO request)
    {
        var (departamentos, totalRecords, filteredRecords) = await _departamentosRepository.GetAllDepartamentosAsync(request);
        var departamentoDTOs = departamentos.Select(d => new DepartamentoDTO
        {
            Id = d.IdDepartamento,
            Nombre = d.Nombre,
            Descripcion = d.Descripcion ?? string.Empty,
            Activo = d.Activo
        });

        PagedResult<DepartamentoDTO> result = new PagedResult<DepartamentoDTO>
        {
            Items = departamentoDTOs,
            TotalRecords = totalRecords,
            TotalRecordsFiltered = filteredRecords
        };

        return result;
    }

    public async Task<IEnumerable<DepartamentoDTO>> GetAllDepartamentos()
    {
        var departamentos = await _departamentosRepository.GetAll();
        return departamentos.Select(d => new DepartamentoDTO
        {
            Id = d.IdDepartamento,
            Nombre = d.Nombre,
            Descripcion = d.Descripcion ?? string.Empty,
            Activo = d.Activo
        });
    }

    public async Task<DepartamentoDTO> GetDepartamentoByIdAsync(int id)
    {
        var departamento = await _departamentosRepository.GetByIdAsync(id);
        if (departamento == null)
        {
            throw new KeyNotFoundException($"Departamento with ID {id} not found.");
        }

        return new DepartamentoDTO
        {
            Id = departamento.IdDepartamento,
            Nombre = departamento.Nombre,
            Descripcion = departamento.Descripcion ?? string.Empty,
            Activo = departamento.Activo
        };
    }

    public async Task<bool> CreateDepartamentoAsync(DepartamentoDTO departamento)
    {
        var entity = new Departamento
        {
            Nombre = departamento.Nombre,
            Descripcion = departamento.Descripcion ?? string.Empty,
            Activo = departamento.Activo
        };

        return await _departamentosRepository.AddAsync(entity);
    }

    public async Task<bool> UpdateDepartamentoAsync(DepartamentoDTO departamento)
    {
        var entity = await _departamentosRepository.GetByIdAsync(departamento.Id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Departamento with ID {departamento.Id} not found.");
        }

        entity.Nombre = departamento.Nombre;
        entity.Activo = departamento.Activo;
        entity.Descripcion = departamento.Descripcion ?? string.Empty;

        return await _departamentosRepository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteDepartamentoAsync(int id)
    {
        var entity = await _departamentosRepository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Departamento with ID {id} not found.");
        }

        return await _departamentosRepository.DeleteAsync(entity);
    }
}