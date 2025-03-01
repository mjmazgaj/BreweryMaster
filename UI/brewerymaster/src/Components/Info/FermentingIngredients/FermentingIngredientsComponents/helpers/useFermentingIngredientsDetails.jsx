import { useState, useEffect } from "react";

import { useTranslation } from "react-i18next";

import fermentingIngredientFieldsProvider from "./fermentingIngredientFieldsProvider";
import { apiEndpoints, fetchData, updateData } from "../../../../Shared/api";

export const useFermentingIngredientsDetails = ({
  setShowEditInfoModal,
  setModalData,
  ingredientData,
  setIngredientData,
  setChartAvailableData,
  setCustomModalForm,
  id,
}) => {
  const { t } = useTranslation();
  const [types, setTypes] = useState([]);

  const handleEditInfoOnClick = () => {
    setCustomModalForm("editInfo");

    const { units, ...rest } = ingredientData;
    setModalData(rest);

    setShowEditInfoModal(true);
  };

  const handleQuantity = (action) =>{
    setCustomModalForm(action);
    setModalData({});

    setShowEditInfoModal(true);
  }

  const setPageData = () => {
    fetchData(
      `${apiEndpoints.fermentingIngredientSummary}/${id}`,
      setIngredientData
    );
  };

  const editInfoModalObject = {
    submitFunction: async (data) => {
      await updateData(apiEndpoints.fermentingIngredient, data.id, data);
      setPageData();
    },
    buttons: [
      {
        isSubmit: false,
        label: t("button.add"),
      },
    ],
    title: t("fermentingIngredient.editTitle"),
  };

  const increaseModalObject = {
    submitFunction: async (data) => {
      await updateData(apiEndpoints.fermentingIngredient, data.id, data);
      setPageData();
    },
    buttons: [
      {
        isSubmit: false,
        label: t("button.add"),
      },
    ],
    title: t("fermentingIngredient.increaseModalTitle"),
  };

  const reduceModalObject = {
    submitFunction: async (data) => {
      await updateData(apiEndpoints.fermentingIngredient, data.id, data);
      setPageData();
    },
    buttons: [
      {
        isSubmit: false,
        label: t("button.add"),
      },
    ],
    title: t("fermentingIngredient.reduceModalTitle"),
  };

  const reservationModalObject = {
    submitFunction: async (data) => {
      await updateData(apiEndpoints.fermentingIngredient, data.id, data);
      setPageData();
    },
    buttons: [
      {
        isSubmit: false,
        label: t("button.add"),
      },
    ],
    title: t("fermentingIngredient.reservationModalTitle"),
  };

  const orderModalObject = {
    submitFunction: async (data) => {
      await updateData(apiEndpoints.fermentingIngredient, data.id, data);
      setPageData();
    },
    buttons: [
      {
        isSubmit: false,
        label: t("button.add"),
      },
    ],
    title: t("fermentingIngredient.orderModalTitle"),
  };

  const editInfoModalFields = {
    control: fermentingIngredientFieldsProvider(t).modalFields,
    dropdown: [
      {
        data: types,
        name: "typeId",
        label: t("name.brewery.type"),
      },
    ],
  };

  const storageModalFields = {
    control: fermentingIngredientFieldsProvider(t).storageModalFields,
  };

  const reservationModalFields = {
    control: fermentingIngredientFieldsProvider(t).reservationModalFields,
  };

  const orderModalFields = fermentingIngredientFieldsProvider(t).orderModalFields;

  const modalDataProvider = {
    editInfo: {
      object: editInfoModalObject,
      fields: editInfoModalFields,
    },
    increase: {
      object: increaseModalObject,
      fields: storageModalFields,
    },
    reduce: {
      object: reduceModalObject,
      fields: storageModalFields,
    },
    reservation: {
      object: reservationModalObject,
      fields: reservationModalFields,
    },
    order: {
      object: orderModalObject,
      fields: orderModalFields,
    },
  };

  useEffect(() => {
    setPageData();
    fetchData(apiEndpoints.fermentingIngredientType, setTypes);
  }, []);

  useEffect(() => {
    setChartAvailableData([
      {
        name: "Dostępne",
        value: ingredientData.storedQuantity - ingredientData.reservedQuantity,
      },
      { name: "Zamówione", value: ingredientData.orderedQuantity },
      { name: "Zarezerwowane", value: ingredientData.reservedQuantity },
    ]);
  }, [ingredientData]);

  return { handleEditInfoOnClick, handleQuantity, modalDataProvider };
};
