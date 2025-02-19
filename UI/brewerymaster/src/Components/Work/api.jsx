import api from "../Security/api";

export const fetchDataByOwnerId = (setData) => {
  return api
    .get(`api/task/ByOwnerId`)
    .then((result) => {
      console.log(result);
      setData(result.data);
    })
    .catch((error) => console.log(error));
};

export const fetchDataByOrderId = (id) => {
  return api
    .get(`api/task/ByOrderId/${id}`)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};

export const updateStatus = (data) => {
  return api
    .put(`api/task/EditStatus`, data)
    .then((result) => result.data)
    .catch((error) => console.log(error));
};
