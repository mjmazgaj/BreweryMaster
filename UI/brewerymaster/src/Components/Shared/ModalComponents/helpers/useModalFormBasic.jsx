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

  const handleFormSubmit = (event) => {
    const form = event.currentTarget;
    event.preventDefault();

    if (form.checkValidity() === false || !isValid) {
      event.stopPropagation();
      return false;
    }

    return true;
  };

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

    const updateObject = {
      ...data,
      ...(data?.units ? { units: [...data.units, ...usedUnits] } : {}),
    };

    await updateData(path, data.id, updateObject);
    refreshTableData();

    setShow(false);
  };

  const handleReduce = async (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }

    let reduceAmount = -1 * parseInt(data.quantity);

    await addData(path, { ...data, quantity: reduceAmount });
    refreshTableData();

    setShow(false);
  };

  const handleIncrease = async (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }
    await addData(path, data);
    refreshTableData();

    setShow(false);
  };

  const actionCases = {
    Add: {
      title: itemName,
      function: handleAdd,
      isReadOnly: false,
    },
    Edit: {
      title: `Edit ${data?.name ? data.name : itemName}`,
      function: handleEdit,
      isReadOnly: false,
    },
    Reduce: {
      title: `Reduce ${data?.name ? data.name : itemName}`,
      function: handleReduce,
      isReadOnly: false,
    },
    Increase: {
      title: `Increase ${data?.name ? data.name : itemName}`,
      function: handleIncrease,
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
    handleDateChange,
  };
};
