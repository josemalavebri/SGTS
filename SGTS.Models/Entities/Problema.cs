using System.ComponentModel.DataAnnotations;

namespace SGTS.Models.Entities;

public class Problema
{
    public int Id { get; set; }

    [Required, MaxLength(500)]
    public string Descripcion { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int EstadoProblemaId { get; set; }
    public EstadoProblema Estado { get; set; }

    public int PrioridadId { get; set; }
    public Prioridad Prioridad { get; set; }

    public DateTime FechaReporte { get; set; }
    public DateTime? FechaResolucion { get; set; }

    public bool Activo { get; set; }
}