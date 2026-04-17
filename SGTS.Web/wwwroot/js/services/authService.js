// services/authService.js

import apiClient from "../core/apiClient.js";
import { API_ROUTES } from "../constants/apiRoutes.js";
import store from "../state/store.js";

const login = async (correo, password) => {
  try {
    const response = await apiClient.post(API_ROUTES.AUTH.LOGIN, {
      correo,
      password,
    });

    const { token, usuario } = response;

    store.setState({
      usuario,
      token,
      isAuthenticated: true,
    });

    return usuario;
  } catch (error) {
    throw new Error("Error al iniciar sesión");
  }
};

const logout = () => {
  store.clear();
};

const getCurrentUser = () => {
  return store.getState().usuario;
};

export default {
  login,
  logout,
  getCurrentUser,
};
