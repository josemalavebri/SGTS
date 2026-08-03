const get = (id) => {
  const element = document.getElementById(id);

  if (!element) {
    throw new Error(`Modal con id "${id}" no encontrado`);
  }

  return bootstrap.Modal.getOrCreateInstance(element);
};

const setTitle = (id, text) => {
  const element = document.getElementById(id);

  if (!element) {
    throw new Error(`Modal con id "${id}" no encontrado`);
  }

  const title = element.querySelector(".modal-title");

  if (!title) {
    console.warn(`El modal "${id}" no tiene .modal-title`);
    return;
  }

  title.textContent = text;
};

const show = (id) => {
  get(id).show();
};

const hide = (id) => {
  get(id).hide();
};

const clean = () => {
  document.querySelectorAll(".modal.show").forEach((modalEl) => {
    const instance = bootstrap.Modal.getInstance(modalEl);
    if (instance) {
      instance.hide();
    }
  });

  document.querySelectorAll(".modal-backdrop").forEach((el) => el.remove());
  document.body.classList.remove("modal-open");
};

export default {
  show,
  hide,
  clean,
  setTitle,
};
