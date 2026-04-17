// services/commonService.js

import apiClient from "../core/apiClient.js";

const getAll = async (endpoint) => {
  return await apiClient.get(endpoint);
};

const getById = async (endpoint, id) => {
  return await apiClient.get(`${endpoint}/${id}`);
};

const create = async (endpoint, data) => {
  return await apiClient.post(endpoint, data);
};

const update = async (endpoint, id, data) => {
  return await apiClient.put(`${endpoint}/${id}`, data);
};

const remove = async (endpoint, id) => {
  return await apiClient.delete(`${endpoint}/${id}`);
};

export default {
  getAll,
  getById,
  create,
  update,
  remove,
};
