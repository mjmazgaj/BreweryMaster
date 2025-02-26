export const useModalFormBasic = ({
  setData,
  setShow,
  isValid,
  modalCustomizationObject,
}) => {
  const handleClose = () => {
    setShow(false);
  };
  const handleCheckBox = (fieldName, category, isChecked) => {
    setData((prevData) => {
      const currentValues = prevData?.[category] || [];

      if (isChecked) {
        if (!currentValues.includes(fieldName)) {
          return {
            ...prevData,
            [category]: [...currentValues, fieldName],
          };
        }
      } else {
        return {
          ...prevData,
          [category]: currentValues.filter((item) => item !== fieldName),
        };
      }

      return prevData;
    });
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
      modalCustomizationObject?.addtionalValidation &&
      !modalCustomizationObject.addtionalValidation(data)
    )
      return;

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
