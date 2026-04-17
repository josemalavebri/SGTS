const requestInterceptors = [];
const responseInterceptors = [];
const errorInterceptors = [];

export function addRequestInterceptor(interceptorFunction) {
  requestInterceptors.push(interceptorFunction);
}

export function addResponseInterceptor(interceptorFunction) {
  responseInterceptors.push(interceptorFunction);
}

export function addErrorInterceptor(interceptorFunction) {
  errorInterceptors.push(interceptorFunction);
}

export async function runRequestInterceptors(config) {
  let modified = { ...config };

  for (const interceptor of requestInterceptors) {
    modified = (await interceptor(modified)) || modified;
  }

  return modified;
}

export async function runResponseInterceptors(response) {
  let modified = response;

  for (const interceptor of responseInterceptors) {
    modified = (await interceptor(modified)) || modified;
  }

  return modified;
}

export async function runErrorInterceptors(error) {
  let modified = error;

  for (const interceptor of errorInterceptors) {
    modified = (await interceptor(modified)) || modified;
  }
  return modified;
}
