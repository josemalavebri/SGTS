/**
 */
const get = (form, fields) => {
  if (!form) return {};

  const data = {};
  const formData = new FormData(form);

  Object.keys(fields).forEach((key) => {
    const input = form.querySelector(`[name="${key}"]`);
    if (!input) return;

    if (input.type === "checkbox") {
      data[key] = input.checked;
    } else if (input.type === "radio") {
      const checkedRadio = form.querySelector(`[name="${key}"]:checked`);
      data[key] = checkedRadio ? checkedRadio.value : null;
    } else {
      data[key] = formData.get(key);
    }
  });

  return data;
};

const set = (form, fields, data) => {
  if (!form || !data) return;

  Object.keys(fields).forEach((key) => {
    const input = form.querySelector(`[name="${key}"]`);
    if (!input) return;

    if (input.type === "checkbox") {
      input.checked = Boolean(data[key]);
    } else if (input.type === "radio") {
      const radio = form.querySelector(`[name="${key}"][value="${data[key]}"]`);
      if (radio) radio.checked = true;
    } else {
      input.value = data[key] ?? "";
    }
  });
};

const reset = (form, fields) => {
  if (!form) return;

  form.reset();

  Object.keys(fields).forEach((key) => {
    const input = form.querySelector(`[name="${key}"]`);
    if (input) {
      if (input.type === "hidden") input.value = "";
      if (input.type === "checkbox") input.checked = false;
    }
  });
};

export default { get, set, reset };
