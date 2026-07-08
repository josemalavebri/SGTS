import formComponent from "../components/form/core/formComponent.js";
import uiModal from "../components/ui/modal.js";

const createUserFormHandler = ({ formConfig, onSubmit, onSuccess }) => {
  const form = formComponent.createFormComponent(formConfig);

  const ui = {
    btnCreate: document.getElementById("btnNew"),
    btnSave: document.getElementById("btnSave"),
    modalId: "userModal",
  };

  const closeAndReset = () => {
    uiModal.hide(ui.modalId);
    uiModal.clean();
    form.set(null);
    form.reset();
  };

  const openModal = (title, data = null) => {
    form.set(data);
    if (!data) form.reset(); 
    uiModal.setTitle(ui.modalId, title);
    uiModal.show(ui.modalId);
  };

  const handleSave = async (e) => {
    e.preventDefault();

    const rawData = await form.submit();
    if (!rawData) return;

    const isEdit = !!rawData.id;
    const payload = {
      nombre: rawData.nombre,
      correo: rawData.correo,
      telefono: rawData.telefono,
      ...(isEdit && { id: Number(rawData.id) }),
    };

    const success = await onSubmit({ payload, isEdit });

    if (success) {
      closeAndReset();
      onSuccess?.();
    }
  };

  ui.btnCreate?.addEventListener("click", () => openModal("Crear Usuario"));
  ui.btnSave?.addEventListener("click", handleSave);

  return {
    handleEditUser: (user) => openModal("Editar Usuario", user),
  };
};

export default { createUserFormHandler };
