import loader from "../components/ui/loader.js";
import "../infrastructure/interceptors/networkInterceptor.js";
import "../infrastructure/interceptors/errorInterceptor.js";

const pages = {
  departamentos: () =>
    import("../pages/administracion/departamento/departamentoPage.js"),
  usuarios: () => import("../pages/administracion/usuarios/usuariosPage.js"),
  usuarioAsignacion: () =>
    import("../pages/administracion/usuarioAsignacion/usuarioAsignacionPage.js"),
  tickets: () => import("../pages/tickets/tickets.js"),
  ticketsDetail: () => import("../pages/tickets/ticketDetailPage.js"),
  createTicketPage: () => import("../pages/tickets/crearTickets.js"),
};

document.addEventListener("DOMContentLoaded", async () => {
  loader.init();
  const app = document.getElementById("app");
  const pageName = app?.dataset.page;

  if (pageName && pages[pageName]) {
    const module = await pages[pageName]();
    console.log("modulo", pageName);
    module.default.init();
  }
});

console.log("CARGANDO MAIN");
