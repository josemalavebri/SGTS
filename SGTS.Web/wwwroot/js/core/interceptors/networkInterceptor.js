import { addErrorInterceptor } from "./interceptors.js";

addErrorInterceptor((error) => {
  if (!error.code) {
    if (error?.name === "AbortError") {
      error.code = "TIMEOUT";
    } else if (!error.status) {
      error.code = "NETWORK";
    } else {
      error.code = "HTTP_ERROR";
    }
  }
  return error;
});
