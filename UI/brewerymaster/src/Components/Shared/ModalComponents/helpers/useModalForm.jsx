import { useEffect } from "react";
import { useTranslation } from "react-i18next";
import { fetchData, addData, updateData } from "../../api";

export const useModalForm = ({
  data,
  show,
  setShow,
  action,
  itemName,
  isValid,
  setData,
  usedUnits,
  setUsedUnits,
  path
}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
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

  const handleCheckBox = (unitId, isChecked) => {
    setData((prevData) => ({
      ...prevData,
      units: isChecked
        ? [...prevData.units, unitId]
        : prevData.units.filter((x) => x !== unitId),
    }));
  };

  const handleSelectChange = (e) => {
    const { value } = e.target;
    setData((prevData) => ({
      ...prevData,
      typeId: parseInt(value),
    }));
  };

  useEffect(() => {
    if (data?.id && show === true)
      fetchData(`FermentingIngredient/Units/${data.id}`, setUsedUnits);

    if (show === false) setUsedUnits([]);
  }, [show, setUsedUnits]);

  const handleAdd = (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }

    addData(path, data)
    setShow(false);
  };

  const handleEdit = (event, data) => {
    if (!handleFormSubmit(event)) {
      return;
    }

    const updateObject = { ...data, units: [...data.units, ...usedUnits]}

    updateData(path, data.id, updateObject)

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
  };
};
