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

const PRIORITY_MAP = {
  alta: "priority-high",
  media: "priority-medium",
  baja: "priority-low",
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

  const ticketElement = clone.querySelector(".ticket-item");

  if (ticketElement) {
    ticketElement.dataset.ticketId = ticket.idTicket;
  }

  const setContent = (selector, value) => {
    const element = clone.querySelector(selector);

    if (element) {
      element.textContent = value;
    }
  };

  // STATUS
  const statusConfig = getStatusConfig(ticket.estado);
  const statusElement = clone.querySelector(".status");

  if (statusElement) {
    statusElement.textContent = statusConfig.label;

    if (statusConfig.className) {
      statusElement.classList.add(statusConfig.className);
    }
  }

  // CONTENIDO
  setContent(".ticket-id", `#TCK-${String(ticket.idTicket).padStart(4, "0")}`);

  setContent(".ticket-title", ticket.titulo ?? "");
  setContent(".ticket-description", ticket.descripcion ?? "");
  setContent(".ticket-category", ticket.categoria ?? "");
  setContent(".ticket-date", formatDate(ticket.fechaCreacion));

  const ticketUrl = `/Tickets/DetalleTicket/${ticket.idTicket}`;

  const viewLink = clone.querySelector(".ticket-view-link");
  const viewButton = clone.querySelector(".ticket-view-btn");

  if (viewLink) {
    viewLink.href = ticketUrl;
  }

  if (viewButton) {
    viewButton.href = ticketUrl;
  }

  console.log("ID:", ticket.idTicket);
  console.log("URL:", ticketUrl);
  console.log("BUTTON:", viewButton);

  // PRIORIDAD
  const priorityElement = clone.querySelector(".ticket-priority");

  if (priorityElement) {
    const priority = ticket.prioridad?.toLowerCase().trim();
    const priorityClass = PRIORITY_MAP[priority];

    priorityElement.textContent = ticket.prioridad ?? "";

    if (priorityClass) {
      priorityElement.classList.add(priorityClass);
    }
  }

  // TÉCNICO
  setContent(
    ".ticket-technician",
    ticket.tecnicoAsignado ?? "Sin técnico asignado",
  );

  // ACTUALIZACIÓN
  setContent(
    ".ticket-updated",
    ticket.fechaActualizacion
      ? `Última actualización: ${formatDate(ticket.fechaActualizacion)}`
      : "Sin actualizaciones",
  );

  // COLUMNA BOOTSTRAP
  const column = document.createElement("div");
  column.className = "col-12 col-lg-6";

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

export default {
  renderTickets,
};
