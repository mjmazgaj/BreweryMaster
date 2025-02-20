export const useModalFormBasic = ({
  setData,
  setShow,
  isValid,
  modalCustomizationObject,
}) => {
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

  const handleFormSubmit = (event, data) => {
    const form = event.currentTarget;
    event.preventDefault();

    if (form.checkValidity() === false || !isValid) {
      event.stopPropagation();
      return;
    }

    if (!modalCustomizationObject.addtionalValidation(data)) return;

    modalCustomizationObject.submitFunction(data);
    setShow(false);
  };

  return {
    handleClose,
    handleCheckBox,
    handleSelectChange,
    handleDateChange,
    handleFormSubmit,
  };
};
