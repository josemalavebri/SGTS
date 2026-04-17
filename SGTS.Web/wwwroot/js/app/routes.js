
import usersPage from "../pages/usuario/userPage.js";

const routes = {
    "#usuarios": usersPage
};

const getCurrentRoute = () => {
    return window.location.hash || "#usuarios";
};

const renderRoute = async () => {
    const route = getCurrentRoute();
    const page = routes[route];

    if (page && page.init) {
        await page.init();
    } else {
        console.warn("Ruta no encontrada:", route);
    }
};

export const initRouter = () => {
    window.addEventListener("hashchange", renderRoute);
    renderRoute(); 
};