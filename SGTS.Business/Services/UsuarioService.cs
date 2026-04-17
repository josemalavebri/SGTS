using SGTS.Business.Const;
using SGTS.Business.Exceptions;
using SGTS.Business.Interfaces;
using SGTS.Data.Entities;
using SGTS.Data.Interfaces;
using SGTS.Models.DTOs;

namespace SGTS.Business.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        private readonly IUsuarioRepository _repository = usuarioRepository;

        public async Task<PagedResult<UsuarioDTO>> Query(DataTableRequest request)
        {
            var result = await _repository.GetPagedAsync(request);

            return new PagedResult<UsuarioDTO>
            {
                Items = result.Items.Select(Map).ToList(),
                TotalRecords = result.TotalRecords,
                TotalRecordsFiltered = result.TotalRecordsFiltered
            };
        }

        public async Task<UsuarioDTO> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _repository.GetByIdAsync(id)
                ?? throw new NotFoundException(BusinessMessages.Usuario.NO_ENCONTRADO);

            return Map(usuario);
        }

        public async Task CrearUsuario(UsuarioDTO dto)
        {
            var existeEmail = await _repository.EmailExistsAsync(dto.Correo);

            if (existeEmail)
                throw new BusinessRuleException(BusinessMessages.Usuario.EMAIL_DUPLICADO);

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Telefono = dto.Telefono,
                Activo = true
            };

            await _repository.AddAsync(usuario);
        }

        public async Task ActualizarUsuario(UsuarioDTO dto)
        {
            var usuario = await _repository.GetByIdAsync(dto.Id)
                ?? throw new NotFoundException(BusinessMessages.Usuario.NO_ENCONTRADO);

            if (!usuario.Activo)
                throw new BusinessRuleException(BusinessMessages.Reglas.OPERACION_NO_PERMITIDA);

            usuario.Nombre = dto.Nombre;
            usuario.Correo = dto.Correo;
            usuario.Telefono = dto.Telefono;

            await _repository.UpdateAsync(usuario);
        }

        public async Task EliminarUsuario(int id)
        {
            var usuario = await _repository.GetByIdAsync(id)
                ?? throw new NotFoundException(BusinessMessages.Usuario.NO_ENCONTRADO);

            if (!usuario.Activo)
                throw new BusinessRuleException(BusinessMessages.Reglas.OPERACION_NO_PERMITIDA);

            await _repository.DeleteAsync(usuario);
        }

        public async Task<IEnumerable<UsuarioDTO>> ObtenerPorNombre(string nombre)
        {
            var usuarios = await _repository.GetByNameAsync(nombre);
            return usuarios.Select(Map);
        }

        private static UsuarioDTO Map(Usuario u) => new()
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Correo = u.Correo,
            Telefono = u.Telefono
        };
    }
}