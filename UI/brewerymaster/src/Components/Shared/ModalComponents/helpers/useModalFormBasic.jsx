import { useEffect } from "react";
import { useTranslation } from "react-i18next";
import { addData, updateData, fetchData } from "../../api";

export const useModalFormBasic = ({
  data,
  setData,
  usedUnits,
  setUsedUnits,
  show,
  setShow,
  action,
  itemName,
  isValid,
  path,
  refreshTableData,
}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
  };
  
  const handleCheckBox = (unitId, isChecked) => {
    setData((prevData) => ({
      ...prevData,
      units: isChecked
        ? [...prevData.units, unitId]
        : prevData.units.filter((x) => x !== unitId),
    }));
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
  

  const handleAdd = async (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }

    await addData(path, data);
    refreshTableData();
    
    setShow(false);
  };

  const handleEdit = async (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }

    
    const updateObject = { ...data, units: [...data.units, ...usedUnits]}
    
    await updateData(path, data.id, updateObject)
    refreshTableData();
    
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


  useEffect(() => {
    if (data?.id && show === true)
      fetchData(`FermentingIngredient/Units/${data.id}`, setUsedUnits);

    if (show === false) setUsedUnits([]);
  }, [show, setUsedUnits]);

  return {
    handleClose,
    actionObject,
    handleCheckBox,
    handleSelectChange,
    handleDateChange
  };
};
