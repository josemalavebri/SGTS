using SGTS.Models.DTOs;

namespace SGTS.Business.Interfaces;

public interface IPrioridadService
{
    Task<IEnumerable<PrioridadDTO>> GetAllPrioridadesAsync();
}