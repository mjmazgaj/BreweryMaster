import api from "./api";

export const register = async (userData) => {
  const response = await api.post("/api/User/Register", userData);
  return response.data;
};

export const login = async (credentials) => {
  const response = await api.post("/login", credentials);
  if (response.data.token) {
    sessionStorage.setItem("token", response.data.token);
  }
  return response.data;
};

export const logout = async () => {
  await api.post("api/user/logout");
  sessionStorage.removeItem("token");
};
