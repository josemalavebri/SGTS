namespace SGTS.Models.DTOs;

public class ProblemaDTOResponse
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public string FechaReporte { get; set; }
    public string NombreUsuario { get; set; }
    public string NombrePrioridad { get; set; }
    public int? ImagenId { get; set; }
}


public class ProblemaDtoRequest
{
    public int UsuarioId { get; set; }
    public int EstadoProblemaId { get; set; }
    public int PrioridadId { get; set; }
    public int? ImagenId { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaReporte { get; set; }
}