import formComponent from "../../../components/form/core/formComponent.js";
import uiModal from "../../../components/ui/modal.js";

const formConfig = {
  formSelector: "#UsuarioForm",
  fields: {
    id: { type: "text" },
    nombre: { type: "text", required: true, minLength: 2, maxLength: 50 },
    apellido: { type: "text", required: true, minLength: 2, maxLength: 50 },
    correo: { type: "email", required: true, maxLength: 100 },
    telefono: { type: "text", required: false, maxLength: 20 },
  },
};

const modalId = "UsuarioModal";

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
  apellido: formData.apellido,
  correo: formData.correo,
  telefono: formData.telefono || null,
  ...(formData.id && { id: Number(formData.id) }),
});

const saveChanges = async ({ event, form, save, onSaved }) => {
  event.preventDefault();

  const formData = await form.submit();

  if (!formData) return;

  const payload = buildPayload(formData);

  const saved = await save({
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
      title: "Crear Usuario",
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
        title: "Crear Usuario",
      }),

    openEdit: (usuario) =>
      open({
        form,
        title: "Editar Usuario",
        data: usuario,
      }),
  };
};

export default {
  init,
};
