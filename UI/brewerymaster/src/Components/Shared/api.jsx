import axios from 'axios';

const apiurl = "https://localhost:7289/api";

export const fetchData = (path, setData) => {
  return axios
    .get(`${apiurl}/${path}`)
    .then((result) => setData(result.data))
    .catch((error) => console.log(error));
};

export const fetchDataById = (path, id, setData) => {
  return axios.get(`${apiurl}/${path}/${id}`)
    .then((result) => setData(result.data))
    .catch((error) => console.log(error));
};

export const fetchEntity = (entity, setEntity) => {
  return axios.get(`${apiurl}/entity/${entity}`)
    .then((result) => setEntity(result.data))
    .catch((error) => console.log(error));
};

export const fetchDetails = (path, setDetails) => {
  return axios.get(`${apiurl}/${path}/Details`)
    .then((result) => setDetails(result.data))
    .catch((error) => console.log(error));
};

export const addData = (path, data) => {
  return axios.post(`${apiurl}/${path}`, data)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const updateData = (path, id, data) => {
  return axios.patch(`${apiurl}/${path}/${id}`, data)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const updateWithoutBody = (path, id) => {
  return axios.patch(`${apiurl}/${path}/${id}`)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const deleteData = (path, id) => {
  return axios.delete(`${apiurl}/${path}/${id}`)
    .then((result) => result.status === 200)
    .catch((error) => console.log(error));
};