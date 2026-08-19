import apiClient from "../infrastructure/apiClient.js";
import { API_ROUTES } from "../constants/apiRoutes.js";

const post = async (ticket) => {
  return await apiClient.post(API_ROUTES.ticket, ticket);
};

export default { post };
