const sortOptions = {
  FechaCreacion_desc: {
    column: "FechaCreacion",
    direction: "Desc",
  },

  FechaCreacion_asc: {
    column: "FechaCreacion",
    direction: "Asc",
  },

  Prioridad_desc: {
    column: "Prioridad",
    direction: "Desc",
  },

  Prioridad_asc: {
    column: "Prioridad",
    direction: "Asc",
  },

  Titulo_asc: {
    column: "Titulo",
    direction: "Asc",
  },

  Titulo_desc: {
    column: "Titulo",
    direction: "Desc",
  },
};

const getSort = () => {
  const sortElement = document.querySelector("#sortFilter");

  if (!sortElement?.value) {
    return null;
  }

  return sortOptions[sortElement.value] ?? null;
};

const initEvents = (onSortChange) => {
  const sortElement = document.querySelector("#sortFilter");

  if (!sortElement) {
    return;
  }

  sortElement.addEventListener("change", () => {
    onSortChange();
  });
};

export default {
  initEvents,
  getSort,
};
