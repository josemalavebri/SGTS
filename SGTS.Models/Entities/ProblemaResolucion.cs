using System.ComponentModel.DataAnnotations;

namespace SGTS.Models.Entities;

public class ProblemaResolucion
{
    public int Id { get; set; }

    public int ProblemaId { get; set; }
    public Problema Problema { get; set; }  // Ya tiene UsuarioId

    public int TecnicoId { get; set; }
    public Tecnico Tecnico { get; set; }

    [Required, MaxLength(500)]
    public string Descripcion { get; set; } // Acción de resolución

    public DateTime Fecha { get; set; } // Fecha de la resolución
    public bool Activo { get; set; }
}