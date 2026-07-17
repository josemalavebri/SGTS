// messages.js

export const MESSAGES = {
  // Éxito
  SUCCESS: {
    SAVE: "Registro guardado correctamente",
    UPDATE: "Registro actualizado correctamente",
    DELETE: "Registro eliminado correctamente",
    FETCH: "Datos obtenidos correctamente",
  },

  // Errores generales
  ERROR: {
    GENERIC: "Ha ocurrido un error inesperado",
    NETWORK: "Error de conexión con el servidor",
    TIMEOUT: "La solicitud ha tardado demasiado",
    UNAUTHORIZED: "No autorizado, inicie sesión nuevamente",
    FORBIDDEN: "No tiene permisos para realizar esta acción",
    NOT_FOUND: "Recurso no encontrado",
    SERVER: "Error interno del servidor",
  },

  // Confirmaciones
  CONFIRM: {
    DELETE: "¿Está seguro de eliminar este registro?",
    LOGOUT: "¿Desea cerrar sesión?",
  },

  // Información
  INFO: {
    LOADING: "Cargando información...",
    EMPTY: "No existen datos para mostrar",
  },
};

export const ALERT_TYPES = {
  SUCCESS: "success",
  ERROR: "error",
  INFO: "info",
  WARNING: "warning",
};
