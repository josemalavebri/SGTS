import UsuarioService from "../../../services/administracion/usuariosService.js";
import alertUI from "../../../components/ui/alert.js";
import { MESSAGES } from "../../../constants/messages.js";
import UsuarioForm from "./UsuariosForm.js";
import UsuarioTable from "./UsuariosTable.js";

const saveUsuario = async ({ payload, isEdit }) => {
  try {
    if (isEdit) {
      await UsuarioService.update(payload.id, payload);
      alertUI.success(MESSAGES.SUCCESS.UPDATE);
    } else {
      await UsuarioService.create(payload);
      alertUI.success(MESSAGES.SUCCESS.SAVE);
    }

    return true;
  } catch {
    return false;
  }
};

const removeUsuario = async (usuario) => {
  const confirmed = await alertUI.confirm({
    message: MESSAGES.CONFIRM.DELETE,
  });

  if (!confirmed) return false;

  await UsuarioService.remove(usuario.id);

  alertUI.success(MESSAGES.SUCCESS.DELETE);

  return true;
};

const loadUsuarios = async (params) => {
  try {
    const response = await UsuarioService.query(params);

    return {
      draw: response?.pagination?.drawn ?? 0,
      data: response?.data ?? [],
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

const init = () => {
  let table;
  let form;

  table = UsuarioTable.init({
    actions: {
      load: loadUsuarios,
      remove: removeUsuario,
    },
    onEdit: (usuario) => form.openEdit(usuario),
    onRemoved: () => table.reload(),
  });

  form = UsuarioForm.init({
    save: saveUsuario,
    onSaved: () => table.reload(),
  });
};

export default {
  init,
};
