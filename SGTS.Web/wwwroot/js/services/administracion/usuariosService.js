import apiClient from "../../infrastructure/apiClient.js";
import { API_ROUTES } from "../../constants/apiRoutes.js";

const query = async (params) => {
  const data = await apiClient.post(API_ROUTES.usuarios.query, params);
  return data;
};

const getByNombre = async (nombre) => {
  return await apiClient.getParams(API_ROUTES.usuarios.buscar, { nombre });
};

const create = async (usuario) => {
  return await apiClient.post(API_ROUTES.usuarios.base, usuario);
};

const update = async (id, usuario) => {
  return await apiClient.put(`${API_ROUTES.usuarios.base}/${id}`, usuario);
};

const remove = async (id) => {
  return await apiClient.delete(`${API_ROUTES.usuarios.base}/${id}`);
};

export default {
  query,
  getByNombre,
  create,
  update,
  remove,
};
