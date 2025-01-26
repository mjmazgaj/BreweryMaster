import axios from 'axios';

const apiurl = "https://localhost:7289/api";

export const fetchDataById = (path, id) => {
  return axios.get(`${apiurl}/${path}/${id}`)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const addData = (path, data) => {
  return axios.post(`${apiurl}/${path}`, data)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const updateData = (path, id, data) => {
  return axios.put(`${apiurl}/${id}/${path}`, data)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const deleteData = (path, id) => {
  return axios.delete(`${apiurl}/${id}/${path}`)
    .then((result) => result.status === 200)
    .catch((error) => console.log(error));
};
