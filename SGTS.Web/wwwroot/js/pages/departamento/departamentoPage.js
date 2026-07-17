import DepartamentoService from "../../services/departamentoService.js";
import alertUI from "../../components/ui/alert.js";
import { MESSAGES } from "../../constants/messages.js";
import DepartamentoForm from "./DepartamentoForm.js";
import DepartamentoTable from "./DepartamentoTable.js";

const saveDepartamento = async ({ payload, isEdit }) => {
  try {
    if (isEdit) {
      await DepartamentoService.update(payload.id, payload);
      alertUI.success(MESSAGES.SUCCESS.UPDATE);
    } else {
      await DepartamentoService.create(payload);
      alertUI.success(MESSAGES.SUCCESS.SAVE);
    }

    return true;
  } catch {
    return false;
  }
};

const removeDepartamento = async (departamento) => {
  const confirmed = await alertUI.confirm({
    message: MESSAGES.CONFIRM.DELETE,
  });

  if (!confirmed) return false;

  await DepartamentoService.remove(departamento.id);

  alertUI.success(MESSAGES.SUCCESS.DELETE);

  return true;
};

const loadDepartamentos = async (params) => {
  try {
    const response = await DepartamentoService.query(params);

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

  table = DepartamentoTable.init({
    actions: {
      load: loadDepartamentos,
      remove: removeDepartamento,
    },
    onEdit: (departamento) => form.openEdit(departamento),
    onRemoved: () => table.reload(),
  });

  form = DepartamentoForm.init({
    save: saveDepartamento,
    onSaved: () => table.reload(),
  });
};

// -------------------- EXPORT --------------------------

export default {
  init,
};
