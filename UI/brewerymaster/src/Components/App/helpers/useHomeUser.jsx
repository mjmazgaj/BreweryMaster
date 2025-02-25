import { apiEndpoints, updateWithoutParameter } from "../../Shared/api";
import { toast } from "react-toastify";

import { useTranslation } from "react-i18next";

export const useHomeUser = ({ setShowPasswordModal }) => {
  const { t } = useTranslation();

  const modalCustomizationObject = {
    addtionalValidation: (data) => {
      if (data?.password != data?.confirmPassword) {
        toast.error(t("toast.passwordNotMatching"));
        return false;
      }
      if (data?.password == data?.currentPassword) {
        toast.error(t("toast.newPasswordShouldBeDifferent"));
        return false;
      }

      return true;
    },
    submitFunction: (data) => updateWithoutParameter(apiEndpoints.userPassword, data),
    buttons: [
      {
        isSubmit: false,
        label: t("button.save"),
      },
    ],
    title: t("user.edditPassword"),
  };

  const handleChangePassword = () => {
    setShowPasswordModal(true);
  };

  return {
    modalCustomizationObject,
    handleChangePassword,
  };
};
