import axios from 'axios';

const apiurl = "https://localhost:7289/api";

export const fetchSummaryData = (ingredient, setSummaryData) => {
  return axios.get(`${apiurl}/${ingredient}/Summary`)
    .then((result) => setSummaryData(result.data))
    .catch((error) => console.log(error));
};

export const fetchIngredientData = (ingredient, tableType, setData) => {
  return axios.get(`${apiurl}/${ingredient}/${tableType}`)
    .then((result) => setData(result.data))
    .catch((error) => console.log(error));
};

export const fetchUnitsById = (ingredient, setUnits, id) => {
  return axios.get(`${apiurl}/${ingredient}/Unit/${id}`)
    .then((result) => setUnits(result.data))
    .catch((error) => console.log(error));
};

export const fetchTypes = (ingredient, setTypes) => {
  return axios.get(`${apiurl}/${ingredient}/Type`)
    .then((result) => setTypes(result.data))
    .catch((error) => console.log(error));
};