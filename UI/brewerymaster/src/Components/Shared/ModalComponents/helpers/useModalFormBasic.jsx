import { useTranslation } from "react-i18next";

export const useModalFormBasic = ({
  data,
  setData,
  setShow,
  action,
  itemName,
  isValid
}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
  };
  
  const handleCheckBox = (item) => {
    setData((prevData) =>({
      ...prevData,
      [item.name]: !prevData[item.name]
    }))
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
  
  const handleSelectChange = (e, name) => {
    const { value } = e.target;
    setData((prevData) => ({
      ...prevData,
      [name]: parseInt(value),
    }));
  };

  const handleDateChange = (date, fieldName) => {
    setData((prevData) => ({
      ...prevData,
      [fieldName]: date,
    }));
  };
  

  const handleAdd = (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }
    console.log("add");
    console.log({...data});
    setShow(false);
  };

  const handleEdit = (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }
    
    console.log("edit");
    console.log({...data});
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
    handleCheckBox,
    handleSelectChange,
    handleDateChange
  };
};
