import { useTranslation } from "react-i18next";

export const useModalItemAction = ({
  data,
  setShow,
  setShowConfirmationModal,
  setShowQuantityModal,
  setShowModalForm,
  setModalAction,
  setQuantityAction,
  action
}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
  };

  const handleEdit = () => {
    setModalAction("edit");
    setShow(false);
    setShowModalForm(true);
  };

  const handleQuantityChange = (data, action) => () => {
    console.log("QuantityChange");
    console.log(data);
    setQuantityAction({
      verb: "add",
      area: action,
    });

    setShow(false);
    setShowQuantityModal(true);
  };

  const handleDelete = () => {
    setShow(false);
    setShowConfirmationModal(true);
  };

  const actionCases = {
    default: {
      title: `${data ? data.name : ""} details`,
      function: () => () => {},
      isReadOnly: true,
    },
    summary: {
      title: `${data ? data.name : ""} details`,
      function: handleQuantityChange,
      isReadOnly: true,
    }
  };

  let actionObject = actionCases[action];

  return {
    handleClose,
    handleDelete,
    handleEdit,
    actionObject,
  };
};
