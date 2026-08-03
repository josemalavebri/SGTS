import formComponent from "../../../components/form/core/formComponent.js";
import formSelect from "../../../components/form/ui/selectForm.js";
import uiModal from "../../../components/ui/modal.js";

const roles = [
  {
    idRol: 1,
    nombre: "Administrador",
  },
  {
    idRol: 2,
    nombre: "tecnico",
  },
  {
    idRol: 3,
    nombre: "empleado",
  },
  {
    idRol: 4,
    nombre: "Supervisor",
  },
];

const departamentos = [
  {
    idDepartamento: 1,
    nombre: "Sistemas",
  },
  {
    idDepartamento: 2,
    nombre: "Talento Humano",
  },
  {
    idDepartamento: 3,
    nombre: "Finanzas",
  },
];

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

const init = ({ onUpdate, onUpdated }) => {
  const form = formComponent.createFormComponent(formConfig);
  document.getElementById("btnSave")?.addEventListener("click", (event) =>
    update({
      event,
      form,
      onUpdate,
      onUpdated,
    }),
  );

  formSelect.fill({
    form: form.getForm(),
    field: "idRol",
    items: roles,
    valueField: "idRol",
    textField: "nombre",
    placeholder: "Seleccione un rol",
  });

  formSelect.fill({
    form: form.getForm(),
    field: "idDepartamento",
    items: departamentos,
    valueField: "idDepartamento",
    textField: "nombre",
    placeholder: "Seleccione un departamento",
  });

  return {
    openEdit: (usuarioAsignado) =>
      open({
        form,
        title: "Asignar Usuario",
        data: usuarioAsignado,
      }),
  };
};

export default {
  init,
};
