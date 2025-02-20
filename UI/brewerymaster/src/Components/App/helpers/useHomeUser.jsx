import { updateWithoutParameter } from "../../Shared/api";
import { toast } from "react-toastify";

import { useTranslation } from "react-i18next";

export const useHomeUser = ({ setShowPasswordModal }) => {
  const { t } = useTranslation();

  const modalCustomizationObject = {
    addtionalValidation: (data) => {
      if (data?.password != data?.confirmPassword) {
        toast.error(t("toast.PasswordNotMatching"));
        return false;
      }
      if (data?.password == data?.currentPassword) {
        toast.error(t("toast.NewPasswordShouldBeDifferent"));
        return false;
      }

      return true;
    },
    submitFunction: (data) => updateWithoutParameter("User/Password", data),
    buttons: [
      {
        isSubmit: false,
        label: "Save",
      },
    ],
    title: "Edit password",
  };

  const handleChangePassword = () => {
    setShowPasswordModal(true);
  };

  return {
    modalCustomizationObject,
    handleChangePassword,
  };
};
