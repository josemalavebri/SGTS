import { httpClient } from "./httpClient.js";
import { API_BASE_URL } from "./config.js";
import loadingStore from "../state/loadingStore.js";

function buildUrl(endpoint) {
  return `${API_BASE_URL}${endpoint}`;
}

async function requestHandler(requestFn) {
  loadingStore.startLoading();
  try {
    return await requestFn();
  } catch (error) {
    throw error;
  } finally {
    loadingStore.stopLoading();
  }
}

// ===================== MÉTODOS =====================

async function get(endpoint) {
  return requestHandler(() => httpClient.get(buildUrl(endpoint)));
}

async function getParams(endpoint, params = {}) {
  return requestHandler(() => httpClient.get(buildUrl(endpoint), { params }));
}

async function post(endpoint, body) {
  return requestHandler(() => httpClient.post(buildUrl(endpoint), body));
}

async function put(endpoint, body) {
  return requestHandler(() => httpClient.put(buildUrl(endpoint), body));
}

async function remove(endpoint) {
  return requestHandler(() => httpClient.delete(buildUrl(endpoint)));
}

export const apiClient = {
  get,
  getParams,
  post,
  put,
  delete: remove,
};
