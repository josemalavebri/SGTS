import loadingStore from "../state/loadingStore.js";
import {
  addRequestInterceptor,
  addResponseInterceptor,
  addErrorInterceptor,
} from "./interceptors.js";

let activeRequests = 0;

function start() {
  activeRequests++;
  if (activeRequests === 1) {
    loadingStore.startLoading();
  }
}

function stop() {
  activeRequests--;
  if (activeRequests <= 0) {
    activeRequests = 0;
    loadingStore.stopLoading();
  }
}

addRequestInterceptor((config) => {
  start();
  return config;
});

addResponseInterceptor((response) => {
  stop();
  return response;
});

addErrorInterceptor((error) => {
  stop();
  return error;
});
