import apiClient from "../infrastructure/apiClient.js";
import { API_ROUTES } from "../constants/apiRoutes.js";

const getAll = async () => {
  return await apiClient.get(API_ROUTES.ticket);
};

const filter = async (filters) => {
  return await apiClient.getParams(`${API_ROUTES.ticket}/filtrar`, filters);
};

const post = async (ticket) => {
  return await apiClient.post(API_ROUTES.ticket, ticket);
};

export default { getAll, filter, post };
