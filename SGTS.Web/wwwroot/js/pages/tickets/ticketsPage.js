import prioridadService from "../../services/administracion/prioridadService.js";
import formComponent from "../../components/form/core/formComponent.js";

const formConfig = {
  formSelector: "#ticketForm",
  fields: {
    prioridad: { type: "select-one", required: true },
  },
};
const selectFillPrioridades = (dataPrioridades, form) => {};

const guardarDatos = async (form) => {
  console.log("guardar datos");
  const formData = await form.validateAndGetData();
  if (!formData) return;

  console.log("FORM DATA:", formData);
};

const initEvents = (form) => {
  console.log("Iniciando init events");
  document
    .getElementById("btnCrear")
    ?.addEventListener("click", () => guardarDatos(form));
};

const initModule = async () => {
  const dataPrioridades = await prioridadService.getAll();
  const form = formComponent.createFormComponent(formConfig);
  form.fillSelect(
    "prioridad",
    dataPrioridades.data,
    "idPrioridad",
    "nombre",
    "Seleccione una prioridad",
  );
  initEvents(form);
};

export default {
  init: initModule,
};
