import ticketService from "../../services/ticketService.js";

import ticketDetail from "./ticketDetail.js";

const loadTicketDetail = async (idTicket) => {
  try {
    console.log("--------- ID TICKET:", idTicket);

    const response = await ticketService.getById(idTicket);

    console.log("--------- DATOS TICKET:", response);

    return response;
  } catch (error) {
    console.error("Error obteniendo detalle del ticket:", error);

    throw error;
  }
};

const init = async () => {
  try {
    console.log("=====================================");

    console.log("🚀 INICIALIZANDO PÁGINA DETALLE");

    console.log("=====================================");

    await ticketDetail.init(loadTicketDetail);
  } catch (error) {
    console.error("Error inicializando página de detalle:", error);
  }
};

export default {
  init,
};
