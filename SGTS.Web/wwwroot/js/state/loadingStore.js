const listeners = new Set();

let state = {
  loading: false,
  counter: 0,
};

const notify = () => {
  listeners.forEach((fn) => fn(state));
};

const setLoading = (value) => {
  state.loading = value;
  notify();
};

const startLoading = () => {
  state.counter++;
  state.loading = true;
  notify();
};

const stopLoading = () => {
  state.counter--;

  if (state.counter <= 0) {
    state.counter = 0;
    state.loading = false;
  }

  notify();
};

const subscribe = (callback) => {
  listeners.add(callback);
  return () => listeners.delete(callback);
};

export default {
  subscribe,
  setLoading,
  startLoading,
  stopLoading,
};
