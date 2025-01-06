import axios from 'axios';

const apiurl = "https://localhost:7289/api";

export const fetchUsers = (setUsers) => {
  return axios.get(`${apiurl}/User`)
    .then((result) => setUsers(result.data))
    .catch((error) => console.log(error));
};