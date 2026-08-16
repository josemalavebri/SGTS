using SGTS.Business.Interfaces;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;

namespace SGTS.Business.Services;

public class PrioridadService : IPrioridadService
{
    private readonly IPrioridadRepository _repository;

    public PrioridadService(IPrioridadRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PrioridadDTO>> GetAllPrioridadesAsync()
    {
        var prioridades = await _repository.GetAllPrioridadesAsync();

        return prioridades.Select(p => new PrioridadDTO
        {
            IdPrioridad = p.IdPrioridad,
            Nombre = p.Nombre
        });
    }
}