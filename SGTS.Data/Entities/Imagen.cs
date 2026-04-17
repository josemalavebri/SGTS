
namespace SGTS.Data.Entities;

public class Imagen
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string TipoMime { get; set; }
    public byte[] Data { get; set; }
}