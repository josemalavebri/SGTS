select *
from roles
select *
from prioridades
select *
from usuarios
select *
from departamentos
select *
from UsuariosAsignaciones

INSERT INTO Usuarios
  (
  Nombre,
  Apellido,
  Correo,
  Telefono,
  PasswordHash,
  Activo,
  FechaCreacion
  )
VALUES
  (
    'Carlos',
    'Mendoza',
    'carlos.mendoza@gmail.com',
    '0998765432',
    'HASH_PASSWORD_AQUI',
    1,
    GETDATE()
);

EXEC sp_help 'Usuarios';
INSERT INTO UsuariosAsignaciones
  (IdUsuario)
VALUES
  (11)
