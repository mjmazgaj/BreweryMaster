import axios from 'axios';

const apiurl = "https://localhost:7289/api/Task";

export const fetchDataByOwnerId = (id) => {
  return axios.get(`${apiurl}/ByOwnerId?ownerId=${id}`)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const fetchDataByOrderId = (id) => {
  return axios.get(`${apiurl}/ByOrderId/${id}`)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const fetchDataById = (id) => {
  return axios.get(`${apiurl}/${id}`)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const addData = (data) => {
  return axios.post(`${apiurl}`, data)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const updateData = (id, data) => {
  return axios.put(`${apiurl}/${id}`, data)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const updateStatus = (data) => {
  return axios.put(`${apiurl}/EditStatus`, data)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const deleteData = (id) => {
  return axios.delete(`${apiurl}/${id}`)
    .then((result) => result.status === 200)
    .catch((error) => console.log(error));
};
