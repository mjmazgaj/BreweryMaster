import { useEffect } from "react";
import { fetchData, updateData, apiEndpoints } from "../../../../Shared/api";

import { useTranslation } from "react-i18next";

export const useUnitsList = ({
  data,
  setShowModal,
  setUnits,
  setEditUnits,
  refreshPageData
}) => {
  const { t } = useTranslation();

  const handleEdit = () => {
    setShowModal(true);
    setEditUnits({
      units: data.units,
    });
  };

  const modalCustomizationObject = {
    submitFunction: async (model) => {
      const requestModel = {
        itemId: data.id,
        unitsId: model.units,
      };

      console.log(requestModel);
        // await updateData(apiEndpoints.userRoles, data.id, requestModel);
        refreshPageData();
    },
    buttons: [
      {
        isSubmit: true,
        label: t("button.save"),
      },
    ],
    title: t("user.roleEdit"),
  };

  useEffect(() => {
    fetchData(apiEndpoints.entityUnit, setUnits);
  }, []);

  return { handleEdit, modalCustomizationObject };
};
