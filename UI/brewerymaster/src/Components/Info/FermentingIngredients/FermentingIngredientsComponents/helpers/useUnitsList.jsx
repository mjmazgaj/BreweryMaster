import { useEffect, useState } from "react";
import { fetchData, updateData, apiEndpoints } from "../../../../Shared/api";

import { useTranslation } from "react-i18next";

export const useUnitsList = ({
  data,
  setShowModal,
  units,
  setUnits,
  setEditUnits,
  refreshPageData,
  setModalFields,
}) => {
  const { t } = useTranslation();

  const handleEditUnitsOnClick = () => {
    console.log(data)
    setModalFields(() => ({
      checkBox: units.map((x) => ({
        ...x,
        label: x.name,
        category: "unitsId",
        isReadOnly: data.units.includes(x.id)
      })),
    }));

    setEditUnits({ unitsId: data.units });
    setShowModal(true);
  };

  const modalCustomizationObject = {
    submitFunction: async (model) => {
      const requestModel = {
        id: data.id,
        unitsId: model.unitsId,
      };

      console.log(requestModel);
      await updateData(apiEndpoints.fermentingIngredientUnit, data.id, requestModel);
      refreshPageData();
    },
    buttons: [
      {
        isSubmit: true,
        label: t("button.save"),
      },
    ],
    title: t("fermentingIngredient.unitEdit"),
  };

  useEffect(() => {
    fetchData(apiEndpoints.entityUnit, setUnits);
  }, []);

  return { handleEditUnitsOnClick, modalCustomizationObject };
};
