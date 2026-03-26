using SGTS.Business.Interfaces;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;

namespace SGTS.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuarioDTO> ObtenerUsuarios()
        {
            var usuarios = _usuarioRepository.ObtenerTodos();

            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Correo
            });
        }

        public UsuarioDTO ObtenerUsuarioPorId(int id)
        {
            var u = _usuarioRepository.ObtenerPorId(id);
            if (u == null) return null;

            return new UsuarioDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Correo
            };
        }
    }
}