import apiClient from "../infrastructure/apiClient.js";
import { API_ROUTES } from "../constants/apiRoutes.js";

const getAll = async () => {
  return await apiClient.get(API_ROUTES.ticket);
};

const post = async (ticket) => {
  return await apiClient.post(API_ROUTES.ticket, ticket);
};

export default { getAll,post };
