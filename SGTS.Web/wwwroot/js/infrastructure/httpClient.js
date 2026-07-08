import { TIMEOUT } from "./config.js";
import {
  runRequestInterceptors,
  runResponseInterceptors,
  runErrorInterceptors,
} from "./interceptors/interceptors.js";

async function fetchWithTimeout(url, options = {}, timeout = TIMEOUT) {
  const controller = new AbortController();

  const id = setTimeout(() => {
    controller.abort();
  }, timeout);

  try {
    return await fetch(url, {
      ...options,
      signal: controller.signal,
    });
  } finally {
    clearTimeout(id);
  }
}

// ===================== ERROR FACTORY =====================

function createHttpError({ status, data, code, name, message }) {
  const error = new Error(message || data?.message || "Unknown error");

  error.name = name;
  error.code = code;
  error.status = status;
  error.data = data;

  return error;
}

// ===================== RESPONSE HANDLER =====================

async function handleResponse(response) {
  if (response.status === 204) {
    return null;
  }

  const contentType = response.headers.get("content-type");

  let data = null;

  if (contentType?.includes("application/json")) {
    try {
      data = await response.json();
    } catch {}
  }

  if (!response.ok) {
    throw createHttpError({
      status: response.status,
      data,
      code: "HTTP_ERROR",
      name: "ServerError",
      message: null,
    });
  }

  return data;
}

// ===================== EXECUTOR =====================

async function execute(method, url, body = null, config = {}) {
  try {
    const finalConfig = await runRequestInterceptors({
      method,
      url,
      body,
      ...config,
    });

    let finalUrl = finalConfig.url;

    const options = {
      method: finalConfig.method,
      headers: { ...(finalConfig.headers || {}) },
    };

    if (finalConfig.params) {
      const query = new URLSearchParams(finalConfig.params).toString();
      finalUrl += `?${query}`;
    }

    if (finalConfig.body) {
      options.body = JSON.stringify(finalConfig.body);

      if (!options.headers["Content-Type"]) {
        options.headers["Content-Type"] = "application/json";
      }
    }

    const response = await fetchWithTimeout(finalUrl, options);

    const interceptedResponse = await runResponseInterceptors(response);

    return await handleResponse(interceptedResponse);
  } catch (err) {
    let finalError;

    // tengo doble mapeo de errores en el interceptor de red y en el de errores, tengo que unificarlo en uno solo para no repetir tanto código, pero de momento lo dejo así para avanzar
    
    if (err?.name === "AbortError") {
      finalError = createHttpError({
        status: null,
        data: null,
        code: "TIMEOUT",
        name: "TimeoutError",
        message: null,
      });
    } else if (err?.code) {
      finalError = createHttpError({
        status: err.status ?? null,
        data: err.data ?? null,
        code: err.code,
        name: err.name || "HttpClientError",
        message: err.message || null,
      });
    } else {
      finalError = createHttpError({
        status: null,
        data: null,
        code: "NETWORK",
        name: "NetworkError",
        message: null,
      });
    }

    throw await runErrorInterceptors(finalError);
  }
}

// ===================== MÉTODOS =====================

export function get(url, config) {
  return execute("GET", url, null, config);
}

export function post(url, body, config) {
  return execute("POST", url, body, config);
}

export function put(url, body, config) {
  return execute("PUT", url, body, config);
}

export function remove(url, config) {
  return execute("DELETE", url, null, config);
}

export const httpClient = {
  get,
  post,
  put,
  delete: remove,
};
