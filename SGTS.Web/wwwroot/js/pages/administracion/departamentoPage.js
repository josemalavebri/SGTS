import tableFactory from "../../components/table/tableFactory.js";
import DepartamentoService from "../../services/departamentoService.js";
import alertUI from "../../components/ui/alert.js";
import { MESSAGES } from "../../constants/messages.js";
import { ALERT_TYPES } from "../../constants/messages.js";
import DepartamentoFormHandler from "./DepartamentoForm.js";

// ======================================================
// CONFIG (declarativo, sin lógica)
// ======================================================
const DepartamentoFormConfig = {
  formSelector: "#DepartamentoForm",
  fields: {
    id: { type: "text" },
    nombre: { type: "text", required: true, minLength: 3, maxLength: 50 },
    descripcion: { type: "text", required: true, minLength: 3, maxLength: 500 },
    activo: { type: "checkbox", required: true },
  },
};

const DepartamentoTableConfig = {
  tableId: "DepartamentoTable",
  columns: [
    { field: "id", label: "ID" },
    { field: "nombre", label: "Nombre" },
    { field: "descripcion", label: "Descripcion" },
    { field: "activo", label: "Activo" },
    { type: "actions", label: "Acciones" },
  ],
};

// ======================================================
// TABLE (adaptador UI)
// ======================================================
const createDepartamentoTable = ({ onEdit, onDelete }) => {
  return tableFactory.createTable({
    tableConfig: DepartamentoTableConfig,
    fetchData: fetchDepartamentoTableData,
    actions: {
      edit: onEdit,
      delete: onDelete,
    },
  });
};

// ======================================================
// FORM (adaptador UI)
// ======================================================
const createDepartamentoFormHandler = ({ onSuccess }) => {
  return DepartamentoFormHandler.init({
    formConfig: DepartamentoFormConfig,
    onSubmit: executeDepartamentoSave,
    onSuccess,
  });
};

// ======================================================
// USE CASES (lógica de aplicación)
// ======================================================
const executeDepartamentoSave = async ({ payload, isEdit }) => {
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

const DeleteDepartamento = async (Departamento) => {
  const confirmed = await alertUI.confirm({
    message: MESSAGES.CONFIRM.DELETE,
  });

  if (!confirmed) return false;

  await DepartamentoService.remove(Departamento.id);
  alertUI.success(MESSAGES.SUCCESS.DELETE);

  return true;
};

// ======================================================
// DATA ADAPTER (API → TABLE)
// ======================================================
const fetchDepartamentoTableData = async (params) => {
  try {
    const response = await DepartamentoService.query(params);
    console.log("response: " + JSON.stringify(response));
    return mapApiToTableFormat(response);
  } catch {
    return getEmptyTableResponse();
  }
};

// ======================================================
// MAPPERS (transformaciones)
// ======================================================
const mapApiToTableFormat = (response) => ({
  draw: response?.pagination?.drawn ?? 0,
  data: response?.data ?? [],
  recordsTotal: response?.pagination?.totalRecords ?? 0,
  recordsFiltered: response?.pagination?.totalRecordsFiltered ?? 0,
});

const getEmptyTableResponse = () => ({
  draw: 0,
  data: [],
  recordsTotal: 0,
  recordsFiltered: 0,
});

// ======================================================
// INIT (composition root)
// ======================================================
const initDepartamentoModule = () => {
  let table;
  let formHandler;

  table = createDepartamentoTable({
    onEdit: (Departamento) => formHandler.handleEditDepartamento(Departamento),
    onDelete: async (Departamento) => {
      const deleted = await DeleteDepartamento(Departamento);
      if (deleted) table.reload();
    },
  });

  formHandler = createDepartamentoFormHandler({
    onSuccess: () => table.reload(),
  });
};

// ======================================================
// API PÚBLICA
// ======================================================
export default { init: initDepartamentoModule };
