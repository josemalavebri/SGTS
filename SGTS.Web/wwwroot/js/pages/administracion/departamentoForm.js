import formComponent from "../../components/form/core/formComponent.js";
import uiModal from "../../components/ui/modal.js";

const closeAndReset = ({ form, modalId }) => {
  uiModal.hide(modalId);
  uiModal.clean();
  form.set(null);
  form.reset();
};

const openModal = ({ form, modalId, title, data = null }) => {
  
  form.set(data);

  if (!data) form.reset();

  uiModal.setTitle(modalId, title);
  uiModal.show(modalId);
};

const handleSave = async ({ event, form, modalId, onSubmit, onSuccess }) => {
  event.preventDefault();

  const rawData = await form.submit();
  if (!rawData) return;

  const isEdit = !!rawData.id;

  const payload = {
    nombre: rawData.nombre,
    descripcion: rawData.descripcion,
    activo: rawData.activo,
    ...(isEdit && { id: Number(rawData.id) }),
  };

  const success = await onSubmit({ payload, isEdit });

  if (success) {
    closeAndReset({ form, modalId });
    onSuccess?.();
  }
};

const initDepartamentoModule = ({ formConfig, onSubmit, onSuccess }) => {
  const form = formComponent.createFormComponent(formConfig);

  const btnCreate = document.getElementById("btnNew");
  const btnSave = document.getElementById("btnSave");
  const modalId = "DepartamentoModal";

  btnCreate?.addEventListener("click", () =>
    openModal({
      form,
      modalId,
      title: "Crear Departamento",
    }),
  );

  btnSave?.addEventListener("click", (event) =>
    handleSave({
      event,
      form,
      modalId,
      onSubmit,
      onSuccess,
    }),
  );

  return {
    handleEditDepartamento: (departamento) =>
      openModal({
        form,
        modalId,
        title: "Editar Departamento",
        data: departamento,
      }),
  };
};

// ======================================================
// API PÚBLICA
// ======================================================

export default {
  init: initDepartamentoModule,
};
