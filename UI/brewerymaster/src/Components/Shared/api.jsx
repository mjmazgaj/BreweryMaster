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

export const addData = async (path, data) => {
  try {
    const result = await axios.post(`${apiurl}/${path}`, data);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const updateData = async (path, id, data) => {
  try {
    const result = await axios.patch(`${apiurl}/${path}/${id}`, data);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const updateWithoutBody = async (path, id) => {
  try {
    const result = await axios.patch(`${apiurl}/${path}/${id}`);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const deleteData = (path, id) => {
  return axios.delete(`${apiurl}/${path}/${id}`)
    .then((result) => result.status === 200)
    .catch((error) => console.log(error));
};