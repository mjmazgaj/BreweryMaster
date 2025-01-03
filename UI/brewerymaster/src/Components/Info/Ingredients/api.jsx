import axios from 'axios';

const apiurl = "https://localhost:7289/api";

export const fetchSummaryData = (ingredient, setSummaryData) => {
console.log(`${apiurl}/${ingredient}/Summary`);

  return axios.get(`${apiurl}/${ingredient}/Summary`)
    .then((result) => setSummaryData(result.data))
    .catch((error) => console.log(error));
};