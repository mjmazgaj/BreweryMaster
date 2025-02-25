import api from "../Security/api";

const apiurl = "/api";

export const fetchData = (path, setData) => {
  return api
    .get(`${apiurl}/${path}`)
    .then((result) => setData(result.data))
    .catch((error) => console.log(error));
};

export const fetchDataById = (path, id, setData) => {
  return api
    .get(`${apiurl}/${path}/${id}`)
    .then((result) => setData(result.data))
    .catch((error) => console.log(error));
};

export const addData = async (path, data) => {
  try {
    const result = await api.post(`${apiurl}/${path}`, data);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const updateData = async (path, id, data) => {
  try {
    const result = await api.patch(`${apiurl}/${path}/${id}`, data);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const updateWithoutBody = async (path, id) => {
  try {
    const result = await api.patch(`${apiurl}/${path}/${id}`);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const updateWithoutParameter = async (path, data) => {
  try {
    const result = await api.patch(`${apiurl}/${path}`, data);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const deleteData = (path, id) => {
  return api
    .delete(`${apiurl}/${path}/${id}`)
    .then((result) => result.status === 200)
    .catch((error) => console.log(error));
};

export const apiEndpoints = {
  task: "Task",
  taskEditStatus: "Task/EditStatus",
  taskDelete: "Task/Delete",
  orderDropDown: "Order/DropDown",
  userDropDown: "User/DropDown",
};
