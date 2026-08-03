import tableFactory from "../../../components/table/tableFactory.js";

const tableConfig = {
  tableId: "UsuarioTable",
  columns: [
    { field: "id", label: "ID" },
    { field: "nombre", label: "Nombre" },
    { field: "apellido", label: "Apellido" },
    { field: "correo", label: "Correo" },
    { field: "telefono", label: "Teléfono" },
    { type: "actions", label: "Acciones" },
  ],
};

const init = ({ actions, onEdit, onRemoved }) => {
  const table = tableFactory.createTable({
    tableConfig,

    fetchData: actions.load,

    actions: {
      edit: onEdit,

      delete: async (usuario) => {
        const removed = await actions.remove(usuario);

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
