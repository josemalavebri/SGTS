import { apiClient } from "../core/apiClient.js";
import { API_ROUTES } from "../constants/apiRoutes.js";

const query = async (params) => {
  const data = await apiClient.post(API_ROUTES.USUARIOS_QUERY, params);
  return data;
};

const getByUsuario = async (nombre) => {
  return await apiClient.getParams(API_ROUTES.USUARIOS_BUSCAR, { nombre });
};

const create = async (usuario) => {
  return await apiClient.post(API_ROUTES.USUARIOS, usuario);
};

const update = async (id, usuario) => {
  return await apiClient.put(`${API_ROUTES.USUARIOS}/${id}`, usuario);
};

const remove = async (id) => {
  return await apiClient.delete(`${API_ROUTES.USUARIOS}/${id}`);
};

export default {
  query,
  getByUsuario,
  create,
  update,
  remove,
};
