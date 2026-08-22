import ticketService from "../../services/ticketService.js";

import ticketFilters from "./filterTicket.js";
import ticketSorting from "./sortingTicket.js";
import ticketList from "./listTicket.js";
import pagination from "./paginationTicket.js";

const getCategoriesMock = async () => {
  await new Promise((resolve) => setTimeout(resolve, 500));

  return [
    {
      idCategoria: 1,
      nombre: "Hardware",
      descripcion:
        "Problemas relacionados con equipos físicos como computadoras, monitores, teclados y otros dispositivos.",
    },
    {
      idCategoria: 2,
      nombre: "Software",
      descripcion:
        "Incidencias relacionadas con aplicaciones, sistemas operativos o programas instalados.",
    },
    {
      idCategoria: 3,
      nombre: "Red",
      descripcion:
        "Problemas de conectividad, acceso a Internet, VPN, Wi-Fi o servicios de red.",
    },
    {
      idCategoria: 4,
      nombre: "Correo",
      descripcion:
        "Incidencias relacionadas con cuentas de correo electrónico, envío, recepción o configuración.",
    },
    {
      idCategoria: 5,
      nombre: "Cuentas",
      descripcion:
        "Solicitudes relacionadas con creación, bloqueo, desbloqueo, restablecimiento de contraseñas y permisos de acceso.",
    },
  ];
};

const buildRequest = () => {
  return {
    pagination: pagination.getParams(),
    order: ticketSorting.getSort(),
    filters: ticketFilters.getFilters(),
  };
};

const loadTickets = async () => {
  try {
    const request = buildRequest();

    console.log("--------- REQUEST", request);

    const response = await ticketService.getAll(request);

    ticketList.renderTickets(response.data);

    pagination.setPagination(response.pagination);
  } catch (error) {
    console.error("Error obteniendo tickets:", error);
  }
};

const reloadFromFirstPage = async () => {
  pagination.reset();

  await loadTickets();
};

const loadTicketDetail = async (idTicket) => {
  try {
    console.log("--------- ID TICKET:", idTicket);

    const response = await ticketService.getById(idTicket);

    console.log("--------- DATOS TICKET:", response);

    return response;
  } catch (error) {
    console.error("Error obteniendo el detalle del ticket:", error);

    throw error;
  }
};

const init = async () => {
  try {
    const categories = await getCategoriesMock();

    ticketFilters.renderCategories(categories);

    pagination.init();

    pagination.onPageChange(loadTickets);

    ticketFilters.initEvents(reloadFromFirstPage);

    ticketSorting.initEvents(reloadFromFirstPage);

    await loadTickets();
  } catch (error) {
    console.error("Error inicializando tickets:", error);
  }
};

export default {
  init,
};
