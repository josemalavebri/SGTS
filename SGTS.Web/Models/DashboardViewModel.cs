using SGTS.Web.Controllers.Web;

namespace SGTS.Web.Models;

public class DashboardViewModel
{
    public List<EstadoDTO> Estados { get; set; }
    public List<PrioridadDTO> Prioridades { get; set; }
}
