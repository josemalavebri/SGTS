// components/alert.js

const showSuccess = (message, title = "Éxito") => {
  return Swal.fire({
    title,
    text: message,
    icon: "success",
    confirmButtonText: "Aceptar",
  });
};

const showError = (message, title = "Error") => {
  return Swal.fire({
    title,
    text: message,
    icon: "error",
    confirmButtonText: "Aceptar",
  });
};

const showConfirm = ({
  message,
  title = "Confirmación",
  confirmText = "Sí",
  cancelText = "Cancelar",
} = {}) => {
  return Swal.fire({
    title,
    text: message,
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: confirmText,
    cancelButtonText: cancelText,
  }).then((result) => result.isConfirmed);
};

export default {
  success: showSuccess,
  error: showError,
  confirm: showConfirm,
};
