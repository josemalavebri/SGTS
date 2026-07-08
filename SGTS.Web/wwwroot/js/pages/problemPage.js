import tableFactory from "../components/table/tableFactory.js";
import problemService from "../services/problemService.js";
import userService from "../services/userService.js";
import alertUI from "../components/ui/alert.js";
import { MESSAGES } from "../constants/messages.js";
import problemFormHandler from "./problemaForm.js";

// ======================================================
// -------------------- MAIN ---------------------------

const formConfig = {
  formSelector: "#problemaForm",
  fields: {
    id: {
      type: "text",
    },
    usuarioId: {
      type: "text",
      required: true,
    },
    descripcion: {
      type: "text",
      required: true,
    },
    estadoProblemaId: {
      type: "text",
      required: true,
    },
    prioridadId: {
      type: "text",
      required: true,
    },
    imagen: {
      type: "file",
    },
  },
};

const init = () => {
  const table = tableFactory.createTable({
    tableId: "problemTable",
    columns: [
      { field: "id", label: "Id" },
      { field: "descripcion", label: "Descripcion" },
      { field: "nombreUsuario", label: "Nombre Usuario" },
      { field: "nombrePrioridad", label: "Prioridad" },
      { field: "imagenId", label: "Imagen" },
    ],
    fetchData: fetchProblemas,
  });

  const formHandler = problemFormHandler.createProblemFormHandler({
    fetchUsuarios: handleFetchUsuarios,
    onSubmit: handleSubmit,
    onSuccess: () => {
      table.reload();
      alertUI.success("Ticket procesado correctamente");
    },
  });

  formHandler.bindEvents();

  document
    .getElementById("btnNewProblema")
    ?.addEventListener("click", formHandler.openCreate);
};

// ======================================================
// -------------------- SUBMIT --------------------------
const handleSubmit = async ({ data, isEdit }) => {
  try {
    const response = isEdit
      ? await problemService.update(data)
      : await problemService.create(data);

    if (!response.success) {
      alertUI.error(
        MESSAGES.ERROR[response.errorCode] || MESSAGES.ERROR.GENERIC,
      );
      return false;
    }

    return true;
  } catch (error) {
    alertUI.error(MESSAGES.ERROR.SERVER);
    return false;
  }
};

// ======================================================
// -------------------- DATA ----------------------------
const fetchProblemas = async (params) => {
  try {
    const response = await problemService.query(params);

    if (!response.success) {
      const errorMsg =
        MESSAGES.ERROR[response.errorCode] || MESSAGES.ERROR.GENERIC;
      alertUI.error(errorMsg);
      return { data: [], recordsTotal: 0, recordsFiltered: 0 };
    }

    return {
      data: response.data,
      recordsTotal: response.pagination?.totalRecords ?? 0,
      recordsFiltered: response.pagination?.totalRecordsFiltered ?? 0,
    };
  } catch (error) {
    alertUI.error(MESSAGES.ERROR.SERVER);
    return { data: [], recordsTotal: 0, recordsFiltered: 0 };
  }
};

const handleFetchUsuarios = async (term) => {
  const response = await userService.getByUsuario(term);
  return response.data || [];
};

// ======================================================
// -------------------- EXPORT --------------------------
export default {
  init,
};
