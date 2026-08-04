import usuarioRolService from "../../../services/administracion/usuariosAsignacionesService.js";
import rolService from "../../../services/administracion/rolService.js";
import departamentoService from "../../../services/administracion/departamentoService.js";

import usuarioAsignacionTable from "./usuarioAsignacionTable.js";
import usuarioAsignacionForm from "./usuarioAsignacionForm.js";

import alertUI from "../../../components/ui/alert.js";
import { MESSAGES } from "../../../constants/messages.js";

const loadUsuariosAsignados = async (params) => {
  try {
    const response = await usuarioRolService.query(params);

    const data = (response?.data ?? []).map((item) => ({
      ...item,
      nombreRol: item.nombreRol === "" ? NaN : item.nombreRol,
      nombreDepartamento:
        item.nombreDepartamento === "" ? NaN : item.nombreDepartamento,
    }));
    return {
      draw: response?.pagination?.drawn ?? 0,
      data,
      recordsTotal: response?.pagination?.totalRecords ?? 0,
      recordsFiltered: response?.pagination?.totalRecordsFiltered ?? 0,
    };
  } catch {
    return {
      draw: 0,
      data: [],
      recordsTotal: 0,
      recordsFiltered: 0,
    };
  }
};

const onUpdate = async ({ payload }) => {
  try {
    await usuarioRolService.update(payload);
    alertUI.success(MESSAGES.SUCCESS.UPDATE);
  } catch (error) {
    return false;
  }
};

const fetchRoles = async () => {
  return await rolService.getAll();
};

const fetchNamesDepartamentos = async () => {
  return await departamentoService.getAllNames();
};

const init = async () => {
  let table;
  let form;
  0;
  table = usuarioAsignacionTable.init({
    loadUsuariosAsignados,
    asignar: (usuarioAsignacion) => form.openEdit(usuarioAsignacion),
  });

  form = await usuarioAsignacionForm.init({
    onUpdate: onUpdate,
    onUpdated: () => table.reload(),
    fetchRoles,
    fetchNamesDepartamentos,
  });
};

export default {
  init,
};
