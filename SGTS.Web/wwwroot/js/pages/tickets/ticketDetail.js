const getTicketId = () => {
  console.log("========== GET TICKET ID ==========");

  const container = document.querySelector(".ticket-detail");

  console.log("Container:", container);

  if (!container) {
    console.error("❌ No se encontró .ticket-detail");

    throw new Error("No se encontró el contenedor del detalle del ticket.");
  }

  console.log("data-ticket-id:", container.dataset.ticketId);

  const idTicket = Number(container.dataset.ticketId);

  console.log("ID convertido a Number:", idTicket);

  if (!idTicket) {
    console.error("❌ El ID del ticket no es válido:", idTicket);

    throw new Error("El ID del ticket no es válido.");
  }

  console.log("✅ ID TICKET:", idTicket);

  return idTicket;
};

const formatDate = (date) => {
  console.log("--------- FORMAT DATE:", date);

  if (!date) {
    console.log("Fecha vacía → No disponible");

    return "No disponible";
  }

  const value = new Date(date);

  console.log("Fecha convertida:", value);

  return (
    value.toLocaleDateString("es-EC", {
      day: "2-digit",
      month: "short",
      year: "numeric",
    }) +
    " · " +
    value.toLocaleTimeString("es-EC", {
      hour: "2-digit",
      minute: "2-digit",
      hour12: false,
    })
  );
};

const formatTicketId = (idTicket) => {
  console.log("--------- FORMAT TICKET ID:", idTicket);

  const formatted = `#TCK-${String(idTicket).padStart(4, "0")}`;

  console.log("Ticket ID formateado:", formatted);

  return formatted;
};

const renderStatus = (element, estado) => {
  console.log("========== RENDER STATUS ==========");

  console.log("Element:", element);

  console.log("Estado:", estado);

  if (!element) {
    console.error("❌ Elemento de estado no encontrado");

    return;
  }

  element.textContent = estado;

  element.className = "status";

  const statusClass = estado
    ?.toLowerCase()
    .normalize("NFD")
    .replace(/[\u0300-\u036f]/g, "")
    .replace(/\s+/g, "-");

  console.log("Clase de estado:", statusClass);

  if (statusClass) {
    element.classList.add(`status-${statusClass}`);
  }

  console.log("✅ Estado renderizado");
};

const renderHeader = (ticket) => {
  console.log("========== RENDER HEADER ==========");

  console.log("Ticket recibido:", ticket);

  const ticketId = document.querySelector("#ticketId");

  const ticketTitle = document.querySelector("#ticketTitle");

  const ticketStatus = document.querySelector("#ticketStatus");

  console.log("ticketId element:", ticketId);

  console.log("ticketTitle element:", ticketTitle);

  console.log("ticketStatus element:", ticketStatus);

  console.log("idTicket:", ticket.idTicket);

  console.log("titulo:", ticket.titulo);

  console.log("estado:", ticket.estado);

  ticketId.textContent = formatTicketId(ticket.idTicket);

  ticketTitle.textContent = ticket.titulo;

  renderStatus(ticketStatus, ticket.estado);

  console.log("✅ Header renderizado");
};

const renderDescription = (ticket) => {
  console.log("========== RENDER DESCRIPTION ==========");

  const element = document.querySelector("#ticketDescription");

  console.log("Description element:", element);

  console.log("Descripción:", ticket.descripcion);

  if (!element) {
    console.error("❌ #ticketDescription no encontrado");

    return;
  }

  element.textContent = ticket.descripcion;

  console.log("✅ Descripción renderizada");
};

const renderTicketInfo = (ticket) => {
  console.log("========== RENDER TICKET INFO ==========");

  console.log("Categoría:", ticket.categoria);

  console.log("Prioridad:", ticket.prioridad);

  console.log("Estado:", ticket.estado);

  console.log("Fecha creación:", ticket.fechaCreacion);

  console.log("Última actualización:", ticket.ultimaActualizacion);

  console.log("Técnico:", ticket.tecnicoAsignado);

  const category = document.querySelector("#ticketCategory");

  const priority = document.querySelector("#ticketPriority");

  const status = document.querySelector("#ticketInfoStatus");

  const createdAt = document.querySelector("#ticketCreatedAt");

  const updatedAt = document.querySelector("#ticketUpdatedAt");

  const technician = document.querySelector("#ticketTechnician");

  console.log("Category element:", category);

  console.log("Priority element:", priority);

  console.log("Status element:", status);

  console.log("CreatedAt element:", createdAt);

  console.log("UpdatedAt element:", updatedAt);

  console.log("Technician element:", technician);

  category.innerHTML = `
    <i class="bi bi-folder me-1"></i>
    ${ticket.categoria}
  `;

  priority.innerHTML = `
    <i class="bi bi-flag-fill me-1"></i>
    ${ticket.prioridad}
  `;

  renderStatus(status, ticket.estado);

  createdAt.textContent = formatDate(ticket.fechaCreacion);

  updatedAt.textContent = formatDate(ticket.ultimaActualizacion);

  if (ticket.tecnicoAsignado) {
    console.log("✅ Técnico encontrado:", ticket.tecnicoAsignado);

    technician.textContent = `${ticket.tecnicoAsignado.nombre}
       ${ticket.tecnicoAsignado.apellido}`;
  } else {
    console.log("⚠️ Ticket sin técnico asignado");

    technician.textContent = "Sin técnico asignado";
  }

  console.log("✅ Información del ticket renderizada");
};

const renderRequester = (ticket) => {
  console.log("========== RENDER REQUESTER ==========");

  const requester = ticket.solicitante;

  console.log("Solicitante:", requester);

  const avatar = document.querySelector("#requesterAvatar");

  const name = document.querySelector("#requesterName");

  console.log("Avatar element:", avatar);

  console.log("Name element:", name);

  if (!requester) {
    console.warn("⚠️ El ticket no tiene solicitante");

    avatar.textContent = "";

    name.textContent = "Sin información";

    return;
  }

  console.log("Nombre:", requester.nombre);

  console.log("Apellido:", requester.apellido);

  const initials = `${requester.nombre.charAt(0)}
     ${requester.apellido.charAt(0)}`;

  console.log("Iniciales:", initials);

  avatar.textContent = initials.toUpperCase();

  name.textContent = `${requester.nombre}
     ${requester.apellido}`;

  console.log("✅ Solicitante renderizado");
};

const createActivityElement = (activity) => {
  console.log("========== CREATE ACTIVITY ==========");

  console.log("Actividad:", activity);

  const item = document.createElement("div");

  item.className = "ticket-timeline__item position-relative pb-4";

  console.log("Tipo actividad:", activity.tipo);

  console.log("Fecha actividad:", activity.fecha);

  item.innerHTML = `
    <span class="ticket-timeline__dot position-absolute"></span>

    <div>

      <div class="fw-semibold">
        ${activity.tipo}
      </div>

      <div class="small text-muted mb-2">
        ${formatDate(activity.fecha)}
      </div>

    </div>
  `;

  console.log("✅ Elemento de actividad creado:", item);

  return item;
};

const renderActivities = (ticket) => {
  console.log("========== RENDER ACTIVITIES ==========");

  console.log("Actividades:", ticket.actividades);

  const timeline = document.querySelector("#ticketTimeline");

  console.log("Timeline element:", timeline);

  timeline.innerHTML = "";

  if (!ticket.actividades?.length) {
    console.warn("⚠️ El ticket no tiene actividades");

    timeline.innerHTML = `
      <div class="text-muted small">
        No existen actividades registradas.
      </div>
    `;

    return;
  }

  console.log("Cantidad de actividades:", ticket.actividades.length);

  ticket.actividades.forEach((activity, index) => {
    console.log(`Actividad [${index}]:`, activity);

    const element = createActivityElement(activity);

    if (index === ticket.actividades.length - 1) {
      element.classList.remove("pb-4");
    }

    timeline.appendChild(element);
  });

  console.log("✅ Actividades renderizadas");
};

const renderTicket = (ticket) => {
  console.log("======================================");

  console.log("========== RENDER TICKET ==========");

  console.log("TICKET COMPLETO:", ticket);

  console.log("======================================");

  if (!ticket) {
    console.error("❌ El ticket recibido es null/undefined");

    return;
  }

  console.log("Ejecutando renderHeader...");

  renderHeader(ticket);

  console.log("Ejecutando renderDescription...");

  renderDescription(ticket);

  console.log("Ejecutando renderTicketInfo...");

  renderTicketInfo(ticket);

  console.log("Ejecutando renderRequester...");

  renderRequester(ticket);

  console.log("Ejecutando renderActivities...");

  renderActivities(ticket);

  console.log("======================================");

  console.log("✅ TICKET RENDERIZADO COMPLETAMENTE");

  console.log("======================================");
};

const loadTicket = async (onLoadTicketDetail) => {
  console.log("======================================");

  console.log("========== LOAD TICKET ==========");

  console.log("Callback recibido:", onLoadTicketDetail);

  try {
    const idTicket = getTicketId();

    console.log("ID que se enviará al callback:", idTicket);

    const response = await onLoadTicketDetail(idTicket);

    console.log("======================================");

    console.log("📦 RESPONSE COMPLETO:", response);

    console.log("📦 RESPONSE.DATA:", response?.data);

    console.log("======================================");

    if (!response) {
      console.error("❌ No se recibió response");

      return;
    }

    if (!response.data) {
      console.error("❌ response.data está vacío");

      return;
    }

    renderTicket(response.data);
  } catch (error) {
    console.error("❌ ERROR OBTENIENDO EL DETALLE DEL TICKET:", error);

    console.error("Mensaje:", error.message);

    console.error("Stack:", error.stack);
  }
};

const init = async (onLoadTicketDetail) => {
  console.log("======================================");

  console.log("🚀 INICIALIZANDO TICKET DETAIL");

  console.log("Callback:", onLoadTicketDetail);

  console.log("======================================");

  await loadTicket(onLoadTicketDetail);

  console.log("🏁 TICKET DETAIL FINALIZADO");
};

export default {
  init,
};
