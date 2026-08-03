import formComponent from "../../../components/form/core/formComponent.js";
import uiModal from "../../../components/ui/modal.js";

const formConfig = {
  formSelector: "#DepartamentoForm",
  fields: {
    id: { type: "text" },
    nombre: { type: "text", required: true, minLength: 3, maxLength: 50 },
    descripcion: {
      type: "text",
      required: true,
      minLength: 3,
      maxLength: 500,
    },
    activo: { type: "checkbox", required: true },
  },
};

const modalId = "DepartamentoModal";

const close = (form) => {
  uiModal.hide(modalId);
  uiModal.clean();
  form.set(null);
  form.reset();
};

const open = ({ form, title, data = null }) => {
  form.set(data);

  if (!data) {
    form.reset();
  }

  uiModal.setTitle(modalId, title);
  uiModal.show(modalId);
};

const buildPayload = (formData) => ({
  nombre: formData.nombre,
  descripcion: formData.descripcion,
  activo: formData.activo,
  ...(formData.id && { id: Number(formData.id) }),
});

const saveChanges = async ({ event, form, save, onSaved }) => {
  event.preventDefault();

  const formData = await form.validateAndGetData();

  if (!formData) return;

  const payload = buildPayload(formData);

  const saved = await  save({
    payload,
    isEdit: !!payload.id,
  });

  if (!saved) return;

  close(form);
  onSaved?.();
};

const init = ({ save, onSaved }) => {
  const form = formComponent.createFormComponent(formConfig);

  document.getElementById("btnNew")?.addEventListener("click", () =>
    open({
      form,
      title: "Crear Departamento",
    }),
  );

  document.getElementById("btnSave")?.addEventListener("click", (event) =>
    saveChanges({
      event,
      form,
      save,
      onSaved,
    }),
  );

  return {
    openCreate: () =>
      open({
        form,
        title: "Crear Departamento",
      }),

    openEdit: (departamento) =>
      open({
        form,
        title: "Editar Departamento",
        data: departamento,
      }),
  };
};

export default {
  init,
};
