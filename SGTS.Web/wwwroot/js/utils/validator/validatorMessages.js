const VALIDATION_MESSAGES = {
  REQUIRED: () => "Este campo es obligatorio",
  MIN_LENGTH: ({ min }) => `Mínimo ${min} caracteres`,
  MAX_LENGTH: ({ max }) => `Máximo ${max} caracteres`,
  PATTERN: () => "Formato inválido",
  EMAIL: () => "Correo inválido",
  NUMERIC: () => "Debe ser numérico",
};

const mapErrorsToMessages = (errorsByField) => {
  const result = {};
  for (const field in errorsByField) {
    result[field] = errorsByField[field].map((error) => {
      const handler = VALIDATION_MESSAGES[error.code];
      return handler ? handler(error.meta || {}) : "Error desconocido";
    });
  }
  return result;
};

export default { mapErrorsToMessages };
