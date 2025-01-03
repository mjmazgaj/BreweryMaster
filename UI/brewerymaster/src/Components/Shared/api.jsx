import axios from 'axios';

const apiurl = "https://localhost:7289/api/entity";

export const fetchEntity = (entity, setEntity) => {
  return axios.get(`${apiurl}/${entity}`)
    .then((result) => setEntity(result.data))
    .catch((error) => console.log(error));
};