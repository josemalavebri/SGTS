

import apiClient from "../../infrastructure/apiClient.js";
import { API_ROUTES } from "../../constants/apiRoutes.js";

const getAll = async () => {
  return await apiClient.get(API_ROUTES.categoria);
};

export default { getAll };
