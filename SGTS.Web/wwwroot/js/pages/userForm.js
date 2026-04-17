import formComponent from "../components/form/core/formComponent.js";
import uiModal from "../components/ui/modal.js";

const createUserFormHandler = ({
  formConfig, // 👈 ahora viene desde afuera
  onSubmit,
  onSuccess,
}) => {
  const userForm = formComponent.createFormComponent(formConfig);

  const openCreate = () => {
    userForm.set(null);
    uiModal.setTitle("userModal", "Crear Usuario");
    uiModal.show("userModal");
  };

  const openEdit = (user) => {
    userForm.set(user);
    uiModal.setTitle("userModal", "Editar Usuario");
    uiModal.show("userModal");
  };

  const handleSubmit = async () => {
    const data = await userForm.submit();
    if (!data) return;

    const isEdit = !!data.id;

    const payload = {
      nombre: data.nombre,
      correo: data.correo,
      telefono: data.telefono,
      ...(isEdit && { id: Number(data.id) }),
    };

    const success = await onSubmit({ payload, isEdit });
    if (!success) return;

    uiModal.hide("userModal");
    uiModal.clean();
    userForm.reset();

    onSuccess?.();
  };

  const bindEvents = () => {
    document.getElementById("btnNew")?.addEventListener("click", openCreate);

    document.getElementById("btnSave")?.addEventListener("click", async (e) => {
      e.preventDefault();
      e.stopPropagation();
      await handleSubmit();
    });
  };

  bindEvents();

  return {
    openEdit,
  };
};

export default { createUserFormHandler };
