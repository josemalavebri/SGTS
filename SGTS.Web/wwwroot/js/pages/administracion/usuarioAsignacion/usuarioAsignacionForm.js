import formComponent from "../../../components/form/core/formComponent.js";
import formSelect from "../../../components/form/ui/formSelect.js";
import uiModal from "../../../components/ui/modal.js";

const titleModal = "Asignacion de Usuario";

const formConfig = {
  formSelector: "#UsuarioAsignacionForm",
  fields: {
    nombreUsuario: { type: "text" },
    idUsuario: { type: "text", required: true },
    idDepartamento: { type: "text", required: true },
    idRol: { type: "text", required: true },
  },
};

const modalId = "UsuarioAsignacionModal";

const close = (form) => {
  form.set(null);
  form.reset(null);
  uiModal.hide(modalId);
  uiModal.clean();
};

const open = ({ form, data = null }) => {
  form.set(data);

  if (!data) {
    form.reset();
  }

  uiModal.setTitle(modalId, titleModal);
  uiModal.show(modalId);
};

const buildPayload = (formData) => ({
  idUsuario: formData.usuarioId,
  idDepartamento: formData.departamentoId,
  idRol: formData.rolId,
});

const update = async ({ event, form, update, onSaved }) => {
  event.preventDefault();

  const formData = await form.validateAndGetData();

  if (!formData) return;

  const payload = buildPayload(formData);

  const updated = await update({
    payload,
  });

  if (!update) return;

  close(form);
  onSaved?.();
};

const initEvents = ({ form, onUpdate, onUpdated }) => {
  document.getElementById("btnSave")?.addEventListener("click", (event) =>
    update({
      event,
      form,
      onUpdate,
      onUpdated,
    }),
  );
};

const loadSelects = async ({ form, fetchRoles, fetchNamesDepartamentos }) => {
  const [rolesResponse, departamentosResponse] = await Promise.all([
    fetchRoles(),
    fetchNamesDepartamentos(),
  ]);

  form.fillSelect({
    field: "idRol",
    items: rolesResponse.data,
    valueField: "idRol",
    textField: "nombre",
    placeholder: "Seleccione un rol",
  });

  form.fillSelect({
    field: "idDepartamento",
    items: departamentosResponse.data,
    valueField: "idDepartamento",
    textField: "nombre",
    placeholder: "Seleccione un departamento",
  });
};

const init = async ({
  onUpdate,
  onUpdated,
  fetchRoles,
  fetchNamesDepartamentos,
}) => {
  const form = formComponent.createFormComponent(formConfig);

  initEvents({
    form,
    onUpdate,
    onUpdated,
  });

  await loadSelects({
    form,
    fetchRoles,
    fetchNamesDepartamentos,
  });

  return createActions(form);
};

export default {
  init,
};
