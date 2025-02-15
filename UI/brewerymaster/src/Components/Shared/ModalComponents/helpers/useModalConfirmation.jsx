import {updateWithoutBody} from '../../api'

import { useTranslation } from "react-i18next";
export const useModalConfirmation = ({id, setShow, confirmationAction, path, refreshTableData}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
  }

  const handleDelete = async () => {
    setShow(false);

    await updateWithoutBody(`${path}/Delete`, id)
    refreshTableData();
  };

  const confirmationCases = {
    delete: {
      title: t("message.deleteConfirmation"),
      function: handleDelete,
    },
  };

  let confirmationObject = confirmationCases[confirmationAction];

  return {
    handleClose,
    confirmationObject
  };
};