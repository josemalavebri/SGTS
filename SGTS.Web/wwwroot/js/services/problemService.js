import { apiClient } from "../infrastructure/apiClient.js";
import { API_ROUTES } from "../constants/apiRoutes.js";

const query = async (params) => {
  return await apiClient.post(API_ROUTES.PROBLEMAS_QUERY, params);
};

const create = async (problema) => {
  return await apiClient.post(API_ROUTES.PROBLEMAS, problema);
};

const update = async (id, problema) => {
  return await apiClient.put(`${API_ROUTES.PROBLEMAS}/${id}`, problema);
};

const remove = async (id) => {
  return await apiClient.delete(`${API_ROUTES.PROBLEMAS}/${id}`);
};

export default {
  query,
  create,
  update,
  remove,
};
