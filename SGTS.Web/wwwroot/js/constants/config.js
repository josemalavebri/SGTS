const ENV = "development";

const CONFIG = {
  development: {
    API_BASE_URL: "http://localhost:5285/api",
    TIMEOUT: 5000,
    ENABLE_LOGS: true,
  },
  production: {
    API_BASE_URL: "https://api.dominio.com/api",
    TIMEOUT: 5000,
    ENABLE_LOGS: false,
  },
};

const currentConfig = CONFIG[ENV];

export const API_BASE_URL = currentConfig.API_BASE_URL;
export const TIMEOUT = currentConfig.TIMEOUT;
export const ENABLE_LOGS = currentConfig.ENABLE_LOGS;
