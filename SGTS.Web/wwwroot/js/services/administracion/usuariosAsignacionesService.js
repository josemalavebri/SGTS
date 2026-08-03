import apiClient from "../../infrastructure/apiClient.js";
import { API_ROUTES } from "../../constants/apiRoutes.js";

const query = async (params) => {
  const data = await apiClient.post(
    API_ROUTES.usuariosAsignaciones.query,
    params,
  );
  return data;
};

const create = async (asignacionRol) => {
  return await apiClient.post(
    API_ROUTES.usuariosAsignaciones.base,
    asignacionRol,
  );
};

const update = async (id, asignacionRol) => {
  return await apiClient.put(
    `${API_ROUTES.usuariosAsignaciones.base}/${id}`,
    asignacionRol,
  );
};

const remove = async (id) => {
  return await apiClient.delete(
    `${API_ROUTES.usuariosAsignaciones.base}/${id}`,
  );
};

export default {
  query,
  create,
  update,
  remove,
};
