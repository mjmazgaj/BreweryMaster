import api from "../Security/api";

const apiurl = "/api";

export const fetchData = (path, setData) => {
  return api
    .get(`${apiurl}/${path}`)
    .then((result) => setData(result.data))
    .catch((error) => console.log(error));
};

export const fetchDataById = (path, id, setData) => {
  return api
    .get(`${apiurl}/${path}/${id}`)
    .then((result) => setData(result.data))
    .catch((error) => console.log(error));
};

export const addData = async (path, data) => {
  try {
    const result = await api.post(`${apiurl}/${path}`, data);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const updateData = async (path, id, data) => {
  try {
    const result = await api.patch(`${apiurl}/${path}/${id}`, data);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const updateWithoutBody = async (path, id) => {
  try {
    const result = await api.patch(`${apiurl}/${path}/${id}`);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const updateWithoutParameter = async (path, data) => {
  try {
    const result = await api.patch(`${apiurl}/${path}`, data);
    return result.data;
  } catch (error) {
    console.log(error);
  }
};

export const deleteData = (path, id) => {
  return api
    .delete(`${apiurl}/${path}/${id}`)
    .then((result) => result.status === 200)
    .catch((error) => console.log(error));
};

export const apiEndpoints = {
  entityUnit: "entity/Unit",
  entityContainer: "entity/Container",

  task: "Task",
  taskEditStatus: "Task/EditStatus",
  taskDelete: "Task/Delete",

  orderDropDown: "Order/DropDown",
  orderStatus: "Order/Status",
  orderDetails: "Order/Details",
  order: "Order",
  orderAll: "Order/All",

  prospectOrder: "ProspectOrder",
  prospectOrderPrice: "ProspectOrder/Price",
  prospectOrderDetails: "ProspectOrder/Details",

  prospectClientDropDown: "ProspectClient/DropDown",

  recipe: "Recipe",
  recipeBeerStyleDropDown: "Recipe/BeerStyle/DropDown",
  recipeTypeDropDown: "Recipe/Type/DropDown",

  userDropDown: "User/DropDown",
  userRole: "User/Role",
  userDetails: "User/Details",
  user: "User",

  fermentingIngredientSummary: "FermentingIngredient/Summary",
  fermentingIngredientOrder: "FermentingIngredient/Order",
  fermentingIngredientReservation: "FermentingIngredient/Reservation",
  fermentingIngredientType: "FermentingIngredient/Type",
  fermentingIngredientUnit: "FermentingIngredient/Unit",
};
