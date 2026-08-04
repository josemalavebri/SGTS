import apiClient from "../../infrastructure/apiClient.js";
import { API_ROUTES } from "../../constants/apiRoutes.js";
import { get } from "../../infrastructure/httpClient.js";

const query = async (params) => {
  const data = await apiClient.post(API_ROUTES.departamentos.query, params);
  return data;
};

const getByNombre = async (nombre) => {
  return await apiClient.getParams(API_ROUTES.departamentos.buscar, { nombre });
};

const getAllNames = async () => {
  return await apiClient.get(API_ROUTES.departamentos.names);
};

const create = async (departamento) => {
  return await apiClient.post(API_ROUTES.departamentos.base, departamento);
};

const update = async (id, departamento) => {
  return await apiClient.put(
    `${API_ROUTES.departamentos.base}/${id}`,
    departamento,
  );
};

const remove = async (id) => {
  return await apiClient.delete(`${API_ROUTES.departamentos.base}/${id}`);
};

export default {
  query,
  getAllNames,
  getByNombre,
  create,
  update,
  remove,
};
