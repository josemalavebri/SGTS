import tableFactory from "../../../components/table/tableFactory.js";

const tableConfig = {
  tableId: "usuarioAsignacion",
  columns: [
    { field: "idUsuario", label: "IdUsuario", visible: false },
    { field: "nombreUsuario", label: "Nombre" },
    { field: "idRol", label: "Rol", visible: false },
    { field: "nombreRol", label: "Nombre del Rol" },
    { field: "idDepartamento", label: "Departamento", visible: false },
    { field: "nombreDepartamento", label: "Nombre del Departamento" },
    { type: "actions", label: "Acciones" },
  ],
};

const init = ({ loadUsuariosAsignados, asignar }) => {
  const table = tableFactory.createTable({
    tableConfig,
    fetchData: loadUsuariosAsignados,
    actions: {
      asignar: asignar,
    },
  });

  return table;
};

export default {
  init,
};
