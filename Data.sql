

DELETE FROM Prioridad WHERE Id = 1

DELETE FROM Prioridad;
DBCC CHECKIDENT ('Prioridad', RESEED, 0);

SELECT
  COLUMN_NAME,
  DATA_TYPE,
  CHARACTER_MAXIMUM_LENGTH,
  IS_NULLABLE,
  COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Prioridad';


SELECT * FROM USUARIOS


select *
from prioridad

SELECT * FROM Problemas
-- Tipos de Prioridad
INSERT INTO Prioridad
  (Nombre)
VALUES
  ('Baja'),
  ('Media'),
  ('Alta');

-- Usuarios
INSERT INTO Usuarios
  (Nombre, Correo, Telefono, Activo)
VALUES
  ('Juan Matamoros', 'juan.matamoros@email.com', '0991234567',1)
-- Problemas
INSERT INTO Problemas
  (UsuarioId, EstadoProblemaId, PrioridadId, ImagenId, Descripcion, FechaReporte, FechaResolucion, Activo)
VALUES
  (1, 1, 3, NULL, 'Error en inicio de sesión', '2026-04-01 08:15:00', NULL, 1),
  (2, 2, 2, NULL, 'Pantalla se congela al cargar', '2026-04-02 09:00:00', '2026-04-03 14:30:00', 1),
  (3, 1, 1, NULL, 'No se guardan los cambios', '2026-04-03 10:20:00', NULL, 1),
  (4, 3, 3, NULL, 'Error al generar reporte', '2026-04-03 11:45:00', '2026-04-05 16:00:00', 1),
  (5, 2, 2, NULL, 'Fallo en notificaciones', '2026-04-04 08:50:00', NULL, 1),
  (6, 1, 1, NULL, 'Problema de sincronización', '2026-04-05 09:30:00', NULL, 1),
  (7, 3, 3, NULL, 'Aplicación cierra inesperadamente', '2026-04-05 14:15:00', '2026-04-06 12:00:00', 1),
  (8, 2, 2, NULL, 'Error en filtros de búsqueda', '2026-04-06 10:10:00', NULL, 1),
  (9, 1, 1, NULL, 'Problema con permisos de usuario', '2026-04-06 12:25:00', NULL, 1),
  (10, 2, 3, NULL, 'Crash al exportar datos', '2026-04-07 09:40:00', NULL, 1);


INSERT INTO Problemas
  (UsuarioId, EstadoProblemaId, PrioridadId, ImagenId, Descripcion, FechaReporte, FechaResolucion, Activo)
VALUES
  (1, 1, 3, NULL, 'Error en inicio de sesión')

SELECT * FROM EstadosProblemas
