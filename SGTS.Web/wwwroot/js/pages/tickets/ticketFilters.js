const searchInput = document.querySelector("#searchInput");
const statusFilter = document.querySelector("#statusFilter");
const priorityFilter = document.querySelector("#priorityFilter");
const categoryFilter = document.querySelector("#categoryFilter");
const resetFiltersButton = document.querySelector("#resetFiltersButton");

const resetFilters = (onFilter) => {
  if (searchInput) {
    searchInput.value = "";
  }

  if (statusFilter) {
    statusFilter.value = "";
  }

  if (priorityFilter) {
    priorityFilter.value = "";
  }

  if (categoryFilter) {
    categoryFilter.value = "";
  }

  onFilter();
};

const renderCategories = (categories = []) => {
  if (!categoryFilter) return;

  categoryFilter.innerHTML = `
    <option value="">Todas las categorías</option>
  `;

  categories.forEach((category) => {
    const option = document.createElement("option");

    option.value = category.idCategoria;
    option.textContent = category.nombre;

    categoryFilter.appendChild(option);
  });
};

const getFilters = () => {
  const filters = {};

  const busqueda = searchInput?.value.trim();

  if (busqueda) {
    filters.Busqueda = busqueda;
  }

  if (statusFilter?.value) {
    filters.IdEstado = Number(statusFilter.value);
  }

  if (priorityFilter?.value) {
    filters.IdPrioridad = Number(priorityFilter.value);
  }

  if (categoryFilter?.value) {
    filters.IdCategoria = Number(categoryFilter.value);
  }

  return filters;
};

const debounce = (callback, delay) => {
  let timeoutId;

  return (...args) => {
    clearTimeout(timeoutId);

    timeoutId = setTimeout(() => {
      callback(...args);
    }, delay);
  };
};

const initEvents = (onFilter) => {
  const debouncedFilter = debounce(onFilter, 500);

  searchInput?.addEventListener("input", debouncedFilter);
  statusFilter?.addEventListener("change", onFilter);
  priorityFilter?.addEventListener("change", onFilter);
  categoryFilter?.addEventListener("change", onFilter);

  resetFiltersButton?.addEventListener("click", () => {
    resetFilters(onFilter);
  });
};

export default {
  renderCategories,
  getFilters,
  initEvents,
};
