import { addErrorInterceptor } from "./interceptors.js";
import alertUI from "../../components/ui/alert.js";

// ===================== CLASIFICACIÓN =====================

addErrorInterceptor((error) => {
  let message;

  switch (error.code) {
    case "TIMEOUT":
      message = "Tiempo de espera agotado";
      break;

    case "NETWORK":
      message = "Error de conexión";
      break;

    case "HTTP_ERROR":
      message = error.data?.message || "Error del servidor";
      break;

    default:
      message = "Error inesperado";
  }

  alertUI.error(message);
  return error;
});
