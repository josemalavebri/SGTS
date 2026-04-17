// Formatear número con separadores
// Entrada: number (valor), string (locale opcional)
// Salida: string (ej: "1.250,5")
export function formatNumber(value, locale = "es-EC") {
  if (value == null || isNaN(value)) return "";
  return new Intl.NumberFormat(locale).format(value);
}

// Formatear fecha corta (dd/mm/yyyy)
// Entrada: Date, string o timestamp
// Salida: string (ej: "18/3/2026")
export function formatDate(value) {
  if (!value) return "";
  const date = new Date(value);
  return date.toLocaleDateString("es-EC");
}

// Formatear fecha larga
// Entrada: Date, string o timestamp
// Salida: string (ej: "18/3/2026 07:45:12")
export function formatDateTime(value) {
  if (!value) return "";
  const date = new Date(value);
  return date.toLocaleString("es-EC");
}

// Formatear porcentaje
// Entrada: number (valor), number (decimales)
// Salida: string (ej: "10.00%")
export function formatPercentage(value, decimals = 2) {
  if (value == null || isNaN(value)) return "";
  return `${value.toFixed(decimals)}%`;
}

// Capitalizar texto
// Entrada: string
// Salida: string (ej: "Hola mundo")
export function capitalize(text) {
  if (!text) return "";
  return text.charAt(0).toUpperCase() + text.slice(1).toLowerCase();
}

// Formatear texto a título (Title Case)
// Entrada: string
// Salida: string (ej: "Hola Mundo")
export function toTitleCase(text) {
  if (!text) return "";
  return text
    .toLowerCase()
    .split(" ")
    .map((word) => capitalize(word))
    .join(" ");
}

// Truncar texto
// Entrada: string (texto), number (longitud máxima)
// Salida: string (ej: "Texto trun...")
export function truncate(text, length = 50) {
  if (!text) return "";
  return text.length > length ? text.substring(0, length) + "..." : text;
}

// Formatear estado booleano
// Entrada: boolean o valor truthy/falsy
// Salida: string ("Sí" o "No")
export function formatBoolean(value) {
  return value ? "Sí" : "No";
}
