import { useEffect } from "react";
import { fetchData, updateData, apiEndpoints } from "../../../Shared/api";

import { useTranslation } from "react-i18next";

export const useUserRoles = ({
  userData,
  setShowModal,
  setRoles,
  setEditRoles,
  refreshPageData
}) => {
  const { t } = useTranslation();

  const handleEdit = () => {
    setShowModal(true);
    setEditRoles({
      roles: userData.roles,
    });
  };

  const modalCustomizationObject = {
    submitFunction: async (model) => {
      const requestModel = {
        userId: userData.id,
        rolesId: model.roles,
      };
        await updateData(apiEndpoints.userRoles, userData.id, requestModel);
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
    fetchData(apiEndpoints.userRole, setRoles);
  }, []);

  return { handleEdit, modalCustomizationObject };
};
