// logger.js

import { ENABLE_LOGS } from "./config.js";

function formatMessage(level, message, data) {
  const timestamp = new Date().toISOString();

  return {
    level,
    message,
    data,
    timestamp,
  };
}

function log(level, message, data = null) {
  if (!ENABLE_LOGS) return;

  const formatted = formatMessage(level, message, data);

  switch (level) {
    case "info":
      console.info(formatted);
      break;
    case "warn":
      console.warn(formatted);
      break;
    case "error":
      console.error(formatted);
      break;
    case "debug":
      console.debug(formatted);
      break;
    default:
      console.log(formatted);
  }
}

export function logInfo(message, data) {
  log("info", message, data);
}

export function logWarn(message, data) {
  log("warn", message, data);
}

export function logError(message, data) {
  log("error", message, data);
}

export function logDebug(message, data) {
  log("debug", message, data);
}
