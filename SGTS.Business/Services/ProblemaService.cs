using SGTS.Business.Interfaces;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;

namespace SGTS.Business.Services;

public class ProblemaService(IProblemaRepository problemaRepository) : IProblemaService
{
    private readonly IProblemaRepository _repository = problemaRepository;

    public async Task<PagedResult<ProblemaDTOResponse>> DataTableQueryService(DataTableRequest request)
    {
        var result = await _repository.DataTableQueryService(request);

        return new PagedResult<ProblemaDTOResponse>
        {
            Items = result.Items.Select(Map).ToList(),
            TotalRecords = result.TotalRecords,
            TotalRecordsFiltered = result.TotalRecordsFiltered
        };
    }

    public async Task CrearProblema(ProblemaDtoRequest dto)
    {
        var entity = new Ticket
        {
            Descripcion = dto.Descripcion,
            FechaReporte = dto.FechaReporte,
            UsuarioId = dto.UsuarioId,
            PrioridadId = dto.PrioridadId,
            ImagenId = dto.ImagenId,
            Activo = true
        };

        await _repository.AddAsync(entity);
    }

    public async Task ActualizarProblema(int id, ProblemaDtoRequest dto)
    {
        var problema = await _repository.GetByIdAsync(id)
            ?? throw new Exception($"No se encontró el problema con id {id}");

        if (!problema.Activo)
            throw new Exception("Operación no permitida");

        problema.Descripcion = dto.Descripcion;
        problema.FechaReporte = dto.FechaReporte;
        problema.UsuarioId = dto.UsuarioId;
        problema.PrioridadId = dto.PrioridadId;
        problema.ImagenId = dto.ImagenId;

        await _repository.UpdateAsync(problema);
    }

    public async Task EliminarProblema(int id)
    {
        var problema = await _repository.GetByIdAsync(id)
            ?? throw new Exception($"No se encontró el problema con id {id}");

        if (!problema.Activo)
            throw new Exception("Operación no permitida");

        await _repository.DeleteAsync(id);
    }

    private static ProblemaDTOResponse Map(Ticket p) => new()
    {
        Id = p.Id,
        Descripcion = p.Descripcion,
        FechaReporte = p.FechaReporte.ToString("yyyy-MM-dd HH:mm"),
        NombreUsuario = p.Usuario?.Nombre,
        NombrePrioridad = p.Prioridad?.Nombre,
        ImagenId = p.ImagenId
    };
}