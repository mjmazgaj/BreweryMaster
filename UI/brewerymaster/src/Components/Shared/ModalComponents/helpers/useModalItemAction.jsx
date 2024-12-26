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
    setShow(false);
  };
  
  const handleQuantityChange = (data) => () => {
    console.log(data);
  };

  const handleDelete = () => {
    setShow(false);
    setShowConfirmationModal(true);
  };

  const actionCases = {
    default: {
      title: `${itemName} details`,
      function: () => () => {},
    },
    summary: {
      title: `${itemName} details`,
      function: handleQuantityChange,
    },
    add: {
      title: `Add ${itemName}`,
      function: handleAdd,
    },
    edit: {
      title: `Edit ${itemName}`,
      function: handleEdit,
    },
  };

  let actionObject = actionCases[action];

  return {
    handleClose,
    handleDelete,
    actionObject
  };
};