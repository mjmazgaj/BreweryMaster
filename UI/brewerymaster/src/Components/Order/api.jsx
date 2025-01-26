import axios from 'axios';

const apiurl = "https://localhost:7289/api";

export const checkPrice = (beerType, containerType, capacity) => {
  return axios.get(`${apiurl}/Price?BeerType=${beerType}&ContainerType=${containerType}&Capacity=${capacity}`)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};
