import prioridadService from "../../services/administracion/prioridadService.js";
import categoriaService from "../../services/administracion/categoriaService.js";
import ticketService from "../../services/ticketService.js";

import { MESSAGES } from "../../constants/messages.js";
import alertUI from "../../components/ui/alert.js";

import formComponent from "../../components/form/core/formComponent.js";

const formConfig = {
  formSelector: "#ticketForm",
  fields: {
    titulo: { type: "text", required: true },
    descripcion: { type: "text", required: true },
    idPrioridad: { type: "select-one", required: true },
    idCategoria: { type: "select-one", required: true },
  },
};

const selectFills = async (form) => {
  const dataPrioridades = await prioridadService.getAll();
  form.fillSelect(
    "prioridad",
    dataPrioridades.data,
    "idPrioridad",
    "nombre",
    "Seleccione una prioridad",
  );

  const dataCategorias = await categoriaService.getAll();
  form.fillSelect(
    "categoria",
    dataCategorias.data,
    "idCategoria",
    "nombre",
    "Seleccione una categoria",
  );
};

const guardarDatos = async (form) => {
  const formData = await form.validateAndGetData();
  if (!formData) return;
  console.log(formData);
  const response = await ticketService.post(formData);
  alertUI.success(MESSAGES.SUCCESS.UPDATE);
};

const initEventsForm = (form) => {
  document
    .getElementById("btnCrear")
    ?.addEventListener("click", () => guardarDatos(form));
};

const initModule = async () => {
  const form = formComponent.createFormComponent(formConfig);
  selectFills(form);

  initEventsForm(form);
};

export default {
  init: initModule,
};
