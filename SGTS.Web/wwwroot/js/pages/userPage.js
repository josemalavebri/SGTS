import tableFactory from "../components/table/tableFactory.js";
import userService from "../services/userService.js";
import alertUI from "../components/ui/alert.js";
import { MESSAGES } from "../constants/messages.js";
import userFormHandler from "./userForm.js";

// ======================================================
// CONFIG (declarativo, sin lógica)
// ======================================================
const userFormConfig = {
  formSelector: "#userForm",
  fields: {
    id: { type: "text" },
    nombre: { type: "text", required: true, minLength: 3, maxLength: 50 },
    correo: { type: "text", required: true, email: true },
    telefono: {
      type: "text",
      required: true,
      numeric: true,
      minLength: 10,
      maxLength: 10,
    },
  },
};

const userTableConfig = {
  tableId: "userTable",
  columns: [
    { field: "id", label: "ID" },
    { field: "nombre", label: "Nombre" },
    { field: "correo", label: "Correo" },
    { field: "telefono", label: "Teléfono" },
    { type: "actions", label: "Acciones" },
  ],
};

// ======================================================
// INIT (composition root)
// ======================================================
const initUserModule = () => {
  let table;
  let formHandler;

  table = createUserTable({
    onEdit: (user) => formHandler.handleEditUser(user),
    onDelete: async (user) => {
      const deleted = await DeleteUser(user);
      if (deleted) table.reload();
    },
  });

  formHandler = createUserFormHandler({
    onSuccess: () => table.reload(),
  });
};

// ======================================================
// TABLE (adaptador UI)
// ======================================================
const createUserTable = ({ onEdit, onDelete }) => {
  return tableFactory.createTable({
    tableConfig: userTableConfig,
    fetchData: fetchUserTableData,
    actions: {
      edit: onEdit,
      delete: onDelete,
    },
  });
};

// ======================================================
// FORM (adaptador UI)
// ======================================================
const createUserFormHandler = ({ onSuccess }) => {
  return userFormHandler.createUserFormHandler({
    formConfig: userFormConfig,
    onSubmit: executeUserSave,
    onSuccess,
  });
};

// ======================================================
// USE CASES (lógica de aplicación)
// ======================================================
const executeUserSave = async ({ payload, isEdit }) => {
  try {
    if (isEdit) {
      await userService.update(payload.id, payload);
      alertUI.success(MESSAGES.SUCCESS.UPDATE);
    } else {
      await userService.create(payload);
      alertUI.success(MESSAGES.SUCCESS.SAVE);
    }

    return true;
  } catch {
    return false;
  }
};

const DeleteUser = async (user) => {
  const confirmed = await alertUI.confirm({
    message: MESSAGES.CONFIRM.DELETE,
  });

  if (!confirmed) return false;

  await userService.remove(user.id);
  alertUI.success(MESSAGES.SUCCESS.DELETE);

  return true;
};

// ======================================================
// DATA ADAPTER (API → TABLE)
// ======================================================
const fetchUserTableData = async (params) => {
  try {
    const response = await userService.query(params);

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
// API PÚBLICA
// ======================================================
export default { init: initUserModule };
