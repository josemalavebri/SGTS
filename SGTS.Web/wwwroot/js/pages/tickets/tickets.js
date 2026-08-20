import ticketService from "../../services/ticketService.js";

import ticketFilters from "./ticketFilters.js";
import ticketList from "./ticketList.js";
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


const init = async () => {
  try {
    const [tickets, categories] = await Promise.all([
      ticketService.getAll(),
      getCategoriesMock(),
    ]);

    ticketList.renderTickets(tickets);

    ticketFilters.renderCategories(categories);

    ticketFilters.initEvents(async () => {
      const filters = ticketFilters.getFilters();

      const tickets = await ticketService.filter(filters);

      ticketList.renderTickets(tickets);
    });
  } catch (error) {
    console.error("Error inicializando tickets:", error);
  }
};

export default {
  init,
};
