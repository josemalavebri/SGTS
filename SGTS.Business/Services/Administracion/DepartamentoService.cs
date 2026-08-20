using SGTS.Business.Interfaces;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;
using SGTS.Models.Query.DTOs;

namespace SGTS.Business.Services;

public class DepartamentoService : IDepartamentoService
{
    private readonly IDepartamentosRepository _departamentosRepository;

    public DepartamentoService(IDepartamentosRepository departamentosRepository)
    {
        _departamentosRepository = departamentosRepository;
    }

    public async Task<PagedResult<DepartamentoDTO>> GetAllDepartamentosAsync()
    {
        return null;
    }

    public async Task<IEnumerable<DepartamentoDTO>> GetAllNames()
    {
        var departamentos = await _departamentosRepository.GetAllNames();
        return departamentos.Select(d => new DepartamentoDTO
        {
            IdDepartamento = d.IdDepartamento,
            Nombre = d.Nombre,
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
            IdDepartamento = departamento.IdDepartamento,
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
        var entity = await _departamentosRepository.GetByIdAsync(departamento.IdDepartamento);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Departamento with ID {departamento.IdDepartamento} not found.");
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