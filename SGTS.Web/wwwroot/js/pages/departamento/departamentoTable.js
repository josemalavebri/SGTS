import tableFactory from "../../components/table/tableFactory.js";

const tableConfig = {
  tableId: "DepartamentoTable",
  columns: [
    { field: "id", label: "ID" },
    { field: "nombre", label: "Nombre" },
    { field: "descripcion", label: "Descripcion" },
    { field: "activo", label: "Activo" },
    { type: "actions", label: "Acciones" },
  ],
};

const init = ({ actions, onEdit, onRemoved }) => {
  const table = tableFactory.createTable({
    tableConfig,

    fetchData: actions.load,

    actions: {
      edit: onEdit,

      delete: async (departamento) => {
        const removed = await actions.remove(departamento);

        if (removed) {
          onRemoved?.();
        }
      },
    },
  });

  return table;
};

export default {
  init,
};
