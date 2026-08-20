import ticketService from "../../services/ticketService.js";

const ticketContainer = document.querySelector("#ticketContainer");
const ticketTemplate = document.querySelector("#ticketTemplate");

const STATUS_MAP = {
  abierto: {
    className: "status-open",
    label: "Abierto",
  },

  "en-progreso": {
    className: "status-progress",
    label: "En proceso",
  },

  resuelto: {
    className: "status-closed",
    label: "Resuelto",
  },

  cerrado: {
    className: "status-closed",
    label: "Cerrado",
  },
};

const formatDate = (date) => {
  if (!date) return "Sin fecha";

  return new Date(date).toLocaleDateString("es-EC", {
    day: "2-digit",
    month: "short",
    year: "numeric",
  });
};

const getStatusConfig = (status) =>
  STATUS_MAP[status] ?? {
    className: "",
    label: status ?? "Sin estado",
  };

const createTicketElement = (ticket) => {
  if (!ticketTemplate) return null;

  const clone = ticketTemplate.content.cloneNode(true);

  const setContent = (selector, value) => {
    const element = clone.querySelector(selector);

    if (element) {
      element.textContent = value;
    }
  };

  const statusConfig = getStatusConfig(ticket.estado);
  const statusElement = clone.querySelector(".status");

  if (statusElement) {
    statusElement.textContent = statusConfig.label;

    if (statusConfig.className) {
      statusElement.classList.add(statusConfig.className);
    }
  }

  setContent(".ticket-id", `#TCK-${String(ticket.idTicket).padStart(4, "0")}`);

  setContent(".ticket-title", ticket.titulo ?? "");
  setContent(".ticket-description", ticket.descripcion ?? "");
  setContent(".ticket-category", ticket.categoria ?? "");
  setContent(".ticket-priority", ticket.prioridad ?? "");
  setContent(".ticket-date", formatDate(ticket.fechaCreacion));

  setContent(
    ".ticket-technician",
    ticket.tecnicoAsignado ?? "Sin técnico asignado",
  );

  setContent(
    ".ticket-updated",
    ticket.fechaActualizacion
      ? `Última actualización: ${formatDate(ticket.fechaActualizacion)}`
      : "Sin actualizaciones",
  );

  // Crear columna Bootstrap
  const column = document.createElement("div");
  column.className = "col-12 col-lg-6";

  // El template contiene el article
  column.appendChild(clone);

  return column;
};

const renderTickets = (tickets = []) => {
  if (!ticketContainer) {
    console.error("#ticketContainer no existe en el DOM");
    return;
  }

  if (!Array.isArray(tickets)) {
    console.error("La respuesta de tickets no es un array:", tickets);

    return;
  }

  ticketContainer.innerHTML = "";

  const fragment = document.createDocumentFragment();

  tickets.forEach((ticket) => {
    const ticketElement = createTicketElement(ticket);

    if (ticketElement) {
      fragment.appendChild(ticketElement);
    }
  });

  ticketContainer.appendChild(fragment);
};

const loadTickets = async () => {
  try {
    const tickets = await ticketService.getAll();

    renderTickets(tickets);
  } catch (error) {
    console.error("Error obteniendo tickets:", error);
  }
};

const filterTickets = async (filters) => {
  try {
    const tickets = await ticketService.filter(filters);

    renderTickets(tickets);
  } catch (error) {
    console.error("Error filtrando tickets:", error);
  }
};

export default {
  loadTickets,
  filterTickets,
  renderTickets,
};
