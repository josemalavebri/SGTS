using SGTS.Data.Entities;

namespace SGTS.Data.Interfaces;

public interface IPrioridadRepository
{
    Task<IEnumerable<Prioridad>> GetAllPrioridadesAsync();
}