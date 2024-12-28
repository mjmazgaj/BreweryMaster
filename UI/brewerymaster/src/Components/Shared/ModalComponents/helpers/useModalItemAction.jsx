import { useTranslation } from 'react-i18next';

export const useModalItemAction = ({
  data,
  setShow,
  setShowConfirmationModal,
  action,
  itemName,
}) => {
  const { t } = useTranslation(); 

  const handleClose = () => {
    setShow(false);
  };

  const handleAdd = (data) => () => {
    console.log(data);
  };
  
  const handleEdit = (data) => () => {
    console.log(data);
    setShow(false);
  };
  
  const handleQuantityChange = (data) => () => {
    console.log(data);
    setShow(false);
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