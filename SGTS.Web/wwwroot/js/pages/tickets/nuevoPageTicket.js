import ticketService from "../../services/ticketService.js";

import alertUI from "../../components/ui/alert.js";

import { MESSAGES } from "../../constants/messages.js";

const form = document.querySelector("#ticketForm");

const createTicketButton = document.querySelector("#createTicketButton");

const ticketTitle = document.querySelector("#ticketTitle");

const ticketCategory = document.querySelector("#ticketCategory");

const ticketPriority = document.querySelector("#ticketPriority");

const ticketDescription = document.querySelector("#ticketDescription");

const ticketTitleError = document.querySelector("#ticketTitleError");

const ticketCategoryError = document.querySelector("#ticketCategoryError");

const ticketPriorityError = document.querySelector("#ticketPriorityError");

const ticketDescriptionError = document.querySelector(
  "#ticketDescriptionError",
);

const init = () => {
  form.addEventListener("submit", handleSubmit);
};

const handleSubmit = async (event) => {
  event.preventDefault();

  clearValidationErrors();

  const isValid = validateForm();

  if (!isValid) {
    return;
  }

  const ticket = collectFormData();

  console.log("CREATE TICKET:", ticket);

  await createTicket(ticket);
};

const validateForm = () => {
  let isValid = true;

  // TÍTULO

  if (!ticketTitle.value.trim()) {
    showFieldError(ticketTitleError, "El título es obligatorio.");

    isValid = false;
  }

  // CATEGORÍA

  if (!ticketCategory.value) {
    showFieldError(ticketCategoryError, "Debes seleccionar una categoría.");

    isValid = false;
  }

  // PRIORIDAD

  if (!ticketPriority.value) {
    showFieldError(ticketPriorityError, "Debes seleccionar una prioridad.");

    isValid = false;
  }

  // DESCRIPCIÓN

  if (!ticketDescription.value.trim()) {
    showFieldError(ticketDescriptionError, "La descripción es obligatoria.");

    isValid = false;
  }

  return isValid;
};

const showFieldError = (element, message) => {
  element.textContent = message;

  element.classList.remove("d-none");
};

const clearValidationErrors = () => {
  clearFieldError(ticketTitleError);

  clearFieldError(ticketCategoryError);

  clearFieldError(ticketPriorityError);

  clearFieldError(ticketDescriptionError);
};

const clearFieldError = (element) => {
  element.textContent = "";

  element.classList.add("d-none");
};

const collectFormData = () => {
  return {
    titulo: ticketTitle.value.trim(),

    idCategoria: Number(ticketCategory.value),

    idPrioridad: Number(ticketPriority.value),

    descripcion: ticketDescription.value.trim(),
  };
};

const createTicket = async (ticket) => {
  createTicketButton.disabled = true;

  try {
    await ticketService.post(ticket);

    await alertUI.success(MESSAGES.SUCCESS.SAVE);

    form.reset();
  } finally {
    createTicketButton.disabled = false;
  }
};

export default {
  init,
};
