using SGTS.Models.DTOs;

namespace SGTS.Business.Interfaces;

public interface IProblemaService
{
    Task<PagedResult<ProblemaDTOResponse>> DataTableQueryService(DataTableRequest request);
    Task CrearProblema(ProblemaDtoRequest problemaDto);
    Task ActualizarProblema(int id, ProblemaDtoRequest problemaDto);
    Task EliminarProblema(int id);
}