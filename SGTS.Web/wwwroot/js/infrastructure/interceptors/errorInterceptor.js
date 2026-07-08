import { addErrorInterceptor } from "./interceptors.js";
import alertUI from "../../components/ui/alert.js";
import { MESSAGES } from "../../constants/messages.js";

addErrorInterceptor((error) => {
  let message;

  switch (error.code) {
    case "TIMEOUT":
      message = MESSAGES.ERROR.TIMEOUT;
      break;

    case "NETWORK":
      message = MESSAGES.ERROR.NETWORK;
      break;

    case "HTTP_ERROR":
      message = error.data?.message || MESSAGES.ERROR.SERVER;
      break;

    default:
      message = MESSAGES.ERROR.GENERIC;
  }

  alertUI.error(message);
  return error;
});
