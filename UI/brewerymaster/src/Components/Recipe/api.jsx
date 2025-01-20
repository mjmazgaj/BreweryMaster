import axios from 'axios';

const apiurl = "https://localhost:7289/api";

export const fetchData = (path, setData) => {
  return axios.get(`${apiurl}/${path}`)
    .then((result) => setData(result.data))
    .catch((error) => console.log(error));
};

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

export const updateData = (id, data) => {
  return axios.put(`${apiurl}/${id}`, data)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const deleteData = (id) => {
  return axios.delete(`${apiurl}/${id}`)
    .then((result) => result.status === 200)
    .catch((error) => console.log(error));
};
