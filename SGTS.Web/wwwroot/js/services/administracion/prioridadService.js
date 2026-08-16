import apiClient from "../../infrastructure/apiClient.js";
import { API_ROUTES } from "../../constants/apiRoutes.js";

const getAll = async () => {
  let datos = await apiClient.get(API_ROUTES.prioridad);
  return datos;
};

export default { getAll };
