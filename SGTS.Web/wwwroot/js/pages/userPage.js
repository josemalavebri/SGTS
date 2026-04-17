import tableFactory from "../components/table/tableFactory.js";
import userService from "../services/userService.js";
import alertUI from "../components/ui/alert.js";
import { MESSAGES } from "../constants/messages.js";
import userFormHandler from "./userForm.js";

// ======================================================
// -------------------- INIT ---------------------------
// ======================================================

const formConfig = {
  formSelector: "#userForm",
  fields: {
    id: {
      type: "text",
    },
    nombre: {
      type: "text",
      required: true,
      minLength: 3,
      maxLength: 50,
    },
    correo: {
      type: "text",
      required: true,
      email: true,
    },
    telefono: {
      type: "text",
      required: true,
      numeric: true,
      minLength: 10,
      maxLength: 10,
    },
  },
};

const tableConfig = {
  tableId: "userTable",
  columns: [
    { field: "id", label: "ID" },
    { field: "nombre", label: "Nombre" },
    { field: "correo", label: "Correo" },
    { field: "telefono", label: "Teléfono" },
    { type: "actions", label: "Acciones" },
  ],
};

const init = () => {
  let table;
  let formHandler;

  table = tableFactory.createTable({
    tableConfig,
    fetchData: fetchUsuarios,
    actions: {
      edit: (user) => formHandler.openEdit(user),
      delete: async (user) => {
        const isDelete = await handleDelete(user);
        if (isDelete) table.reload();
      },
    },
  });

  formHandler = userFormHandler.createUserFormHandler({
    formConfig,
    onSubmit: async ({ payload, isEdit }) => {
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
    },
    onSuccess: () => {
      table.reload();
    },
  });
};

// ======================================================
// -------------------- HELPERS ------------------------
// ======================================================

const fetchUsuarios = async (params) => {
  try {
    const response = await userService.query(params);

    return {
      draw: response?.pagination?.drawn ?? 0,
      data: response?.data ?? [],
      recordsTotal: response?.pagination?.totalRecords ?? 0,
      recordsFiltered: response?.pagination?.totalRecordsFiltered ?? 0,
    };
  } catch (err) {
    return {
      draw: 0,
      data: [],
      recordsTotal: 0,
      recordsFiltered: 0,
    };
  }
};

const handleDelete = async (user) => {
  const confirmed = await alertUI.confirm({
    message: MESSAGES.CONFIRM.DELETE,
  });

  if (!confirmed) return false;

  await userService.remove(user.id);
  alertUI.success(MESSAGES.SUCCESS.DELETE);

  return true;
};

// -------------------- EXPORT -------------------------
export default { init };
