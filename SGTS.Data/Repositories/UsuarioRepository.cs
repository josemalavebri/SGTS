using SGTS.Data.Context;
using SGTS.Data.Interfaces;
using SGTS.Models.Entities;

namespace SGTS.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Usuario> ObtenerTodos()
    {
        return _context.Usuarios.ToList();
    }

    public Usuario ObtenerPorId(int id)
    {
        return _context.Usuarios.Find(id);
    }
}