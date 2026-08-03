const clear = (select, placeholder = "Seleccione una opción") => {
  if (!(select instanceof HTMLSelectElement)) return;

  select.innerHTML = "";

  const option = document.createElement("option");
  option.value = "";
  option.textContent = placeholder;

  select.appendChild(option);
};

const fill = ({
  form,
  field,
  items,
  valueField,
  textField,
  placeholder = "Seleccione una opción",
}) => {
  if (!(form instanceof HTMLFormElement)) return;
  if (!Array.isArray(items)) return;

  const select = form.elements[field];

  if (!(select instanceof HTMLSelectElement)) return;

  clear(select, placeholder);

  items.forEach((item) => {
    const option = document.createElement("option");

    option.value = item[valueField];
    option.textContent = item[textField];

    select.appendChild(option);
  });
};

export default {
  clear,
  fill,
};
