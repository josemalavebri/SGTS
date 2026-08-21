import apiClient from "../infrastructure/apiClient.js";
import { API_ROUTES } from "../constants/apiRoutes.js";

const getAll = async (request = {}) => {
  const params = {};

  const pagination = request.pagination;

  if (pagination) {
    params["Pagination.Start"] = pagination.start;
    params["Pagination.Length"] = pagination.length;
  }

  const order = request.order;

  if (order) {
    params["Order.Column"] = order.column;
    params["Order.Direction"] = order.direction;
  }

  const filters = request.filters;

  if (filters) {
    Object.entries(filters).forEach(([key, value]) => {
      if (value !== null && value !== undefined && value !== "") {
        params[`Filters.${key}`] = value;
      }
    });
  }

  console.log("QUERY PARAMS:", params);

  return await apiClient.getParams(API_ROUTES.ticket, params);
};

const getById = async (id) => {
  return await apiClient.getParams(API_ROUTES.ticket, id);
};
const post = async (ticket) => {
  return await apiClient.post(API_ROUTES.ticket, ticket);
};

export default {
  getAll,
  getById,
  post,
};
