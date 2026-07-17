import loader from "../components/ui/loader.js";
import "../infrastructure/interceptors/networkInterceptor.js";
import "../infrastructure/interceptors/errorInterceptor.js";

const pages = {
  departamentos: () => import("../pages/departamento/departamentoPage.js"),
  problemas: () => import("../pages/problemas/problemaPage.js"),
};

document.addEventListener("DOMContentLoaded", async () => {
  loader.init();
  const app = document.getElementById("app");
  const pageName = app?.dataset.page;
  if (pageName && pages[pageName]) {
    const module = await pages[pageName]();
    module.default.init();
  }
});
