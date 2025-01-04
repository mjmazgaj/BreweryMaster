export const useFormControls = ({ setData, setIsValid, invalidFields, setInvalidFields }) => {
  const validateNumber = (value, validation, id) => {
    const isInvalid = validation
      ? value > validation.max || value < validation.min
      : false;

    setInvalidFields((prev) => {
      const updatedFields = { ...prev, [id]: isInvalid };
      const isValidNow = !Object.values(updatedFields).some((isInvalid) => isInvalid);
      setIsValid(isValidNow);
      return updatedFields;
    });
  };

  const validateText = (value, validation, id) => {
    const isInvalid = validation ? value.length > validation.maxLength : false;

    setInvalidFields((prev) => {
      const updatedFields = { ...prev, [id]: isInvalid };
      const isValidNow = !Object.values(updatedFields).some((isInvalid) => isInvalid);
      setIsValid(isValidNow);
      return updatedFields;
    });
  };

  const validation = (value, field) => {
    switch (field.type) {
      case "number":
        validateNumber(value, field.validation, field.id);
        break;
      case "text":
        validateText(value, field.validation, field.id);
        break;
      default:
        setInvalidFields((prev) => {
          const updatedFields = { ...prev, [field.id]: false };
          const isValidNow = !Object.values(updatedFields).some((isInvalid) => isInvalid);
          setIsValid(isValidNow);
          return updatedFields;
        });
        break;
    }
  };

  const handleInputChange = (e, field) => {
    const { id, value, type } = e.target;
    validation(value, field);
    setData((prevData) => ({
      ...prevData,
      [id]: type === "number" ? parseFloat(value) : value,
    }));
  };

  return {
    handleInputChange,
  };
};
