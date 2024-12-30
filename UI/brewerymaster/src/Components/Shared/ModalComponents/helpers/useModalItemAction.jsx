import { useTranslation } from 'react-i18next';

export const useModalItemAction = ({
  data,
  setShow,
  setShowConfirmationModal,
  setShowQuantityModal,
  setQuantityAction,
  action,
  itemName,
}) => {
  const { t } = useTranslation(); 

  const handleClose = () => {
    setShow(false);
  };

  const handleAdd = (data) => () => {
    console.log("Add");
    console.log(data);
  };
  
  const handleEdit = (data) => () => {
    console.log("Add");
    console.log(data);
    setShow(false);
  };
  
  const handleQuantityChange = (data, action) => () => {
    console.log("QuantityChange");
    console.log(data);
    setQuantityAction(action);
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
    },
    add: {
      title: `Add ${itemName}`,
      function: handleAdd,
      isReadOnly: false,
    },
    edit: {
      title: `Edit ${data ? data.name : ""}`,
      function: handleEdit,
      isReadOnly: false,
    },
  };

  let actionObject = actionCases[action];

  return {
    handleClose,
    handleDelete,
    actionObject
  };
};