import { useState, useEffect } from "react";

import { useTranslation } from "react-i18next";

import fermentingIngredientFieldsProvider from "./fermentingIngredientFieldsProvider";
import { apiEndpoints, fetchData, updateData } from "../../../../Shared/api";

export const useFermentingIngredientsDetails = ({
  setModalFields,
  setShowEditInfoModal,
  setModalData,
  ingredientData,
  setIngredientData,
  setChartAvailableData,
  id,
}) => {
  const { t } = useTranslation();
  const [types, setTypes] = useState([]);

  const handleEditInfoOnClick = () => {
    setModalFields(() => ({
      control: fermentingIngredientFieldsProvider(t).modalFields,
      dropdown: [
        {
          data: types,
          name: "typeId",
          label: t("name.brewery.type"),
        },
      ],
    }));

    const { units, ...rest } = ingredientData;
    setModalData(rest);

    setShowEditInfoModal(true);
  };

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

  return { handleEditInfoOnClick, editInfoModalObject };
};
