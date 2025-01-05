import { useTranslation } from "react-i18next";

export const useModalForm = ({
  data,
  setShow,
  action,
  itemName,
  units,
  isValid
}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
  };

  const handleFormSubmit = (event) =>{
    const form = event.currentTarget;
    event.preventDefault();

    if (form.checkValidity() === false || !isValid) {
      event.stopPropagation();
      return false;
    }

    return true;
  }

  const handleAdd = (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }
    const updatedUnits = units.map((x) => ({
      ...x,
      isUsed: x.isUsed ?? false,
    }));

    console.log("add");
    console.log({...data, units: {...updatedUnits}});
    setShow(false);
  };

  const handleEdit = (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }
    const updatedUnits = units.map((x) => ({
      ...x,
      isUsed: x.isUsed ?? false,
    }));
    
    console.log("edit");
    console.log({...data, units: {...updatedUnits}});
    setShow(false);
  };

  const actionCases = {
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
    actionObject,
  };
};
