export const useCustomForm = ({
  setData,
  isValid,
  formCustomizationObject,
}) => {
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
      [name]: value,
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

    if (
      formCustomizationObject?.addtionalValidation &&
      !formCustomizationObject.addtionalValidation(data)
    )
      return;
      
      formCustomizationObject.submitFunction(data);
  };

  return {
    handleCheckBox,
    handleSelectChange,
    handleDateChange,
    handleFormSubmit,
  };
};
