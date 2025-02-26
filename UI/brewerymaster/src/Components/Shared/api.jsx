import api from "../Security/api";

import { toast } from "react-toastify";

import i18next from "i18next";

const apiurl = "/api";

export const fetchData = (path, setData) => {
  return api
    .get(`${apiurl}/${path}`)
    .then((result) => setData(result.data))
    .catch((error) => console.log(error));
};

export const addData = async (
  path,
  data,
  successMessage = i18next.t("toast.addSuccess"),
  errorMessage = i18next.t("toast.addFail")
) => {
  try {
    const result = await api.post(`${apiurl}/${path}`, data);
    toast.success(successMessage);
    return result.data;
  } catch (error) {
    console.log(error);
    toast.error(errorMessage);
  }
};

export const updateData = async (
  path,
  id,
  data,
  successMessage = i18next.t("toast.updateSuccess"),
  errorMessage = i18next.t("toast.updateFail")
) => {
  try {
    const result = await api.patch(`${apiurl}/${path}/${id}`, data);
    toast.success(successMessage);
    return result.data;
  } catch (error) {
    console.log(error);
    toast.error(errorMessage);
  }
};

export const updateWithoutBody = async (
  path,
  id,
  successMessage = i18next.t("toast.updateSuccess"),
  errorMessage = i18next.t("toast.updateFail")
) => {
  try {
    const result = await api.patch(`${apiurl}/${path}/${id}`);
    toast.success(successMessage);
    return result.data;
  } catch (error) {
    console.log(error);
    toast.error(errorMessage);
  }
};

export const updateWithoutParameter = async (
  path,
  data,
  successMessage = i18next.t("toast.updateSuccess"),
  errorMessage = i18next.t("toast.updateFail")
) => {
  try {
    const result = await api.patch(`${apiurl}/${path}`, data);
    toast.success(successMessage);
    return result.data;
  } catch (error) {
    console.log(error);
    toast.error(errorMessage);
  }
};

export const apiEndpoints = {
  entityUnit: "entity/Unit",
  entityContainer: "entity/Container",

  task: "Task",
  taskEditStatus: "Task/Status",
  taskTemplate: "Task/Template",
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
  userRoles: "User/Roles",
  userDetails: "User/Details",
  userPassword: "User/Password",
  user: "User",

  fermentingIngredientSummary: "FermentingIngredient/Summary",
  fermentingIngredientOrder: "FermentingIngredient/Order",
  fermentingIngredientReservation: "FermentingIngredient/Reservation",
  fermentingIngredientType: "FermentingIngredient/Type",
  fermentingIngredientUnit: "FermentingIngredient/Unit",
};
