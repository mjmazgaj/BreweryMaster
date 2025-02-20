import { useEffect } from "react";

export const useFormControls = ({ setData, setIsValid, invalidFields, setInvalidFields }) => {
  const validateNumber = (value, validation) => {
    return validation ? value > validation.max || value < validation.min : false;
  };

  const validateText = (value, validation) => {
    return validation ? value.length > validation.maxLength : false;
  };

  const validateEmail = (value, validation) => {
    if (validateText(value, validation)) return true;
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return !emailRegex.test(value);
  };

  const validation = (value, field) => {
    let isInvalid = false;

    switch (field.type) {
      case "number":
        isInvalid = validateNumber(value, field.validation);
        break;
      case "text":
      case "password":
        isInvalid = validateText(value, field.validation);
        break;
      case "email":
        isInvalid = validateEmail(value, field.validation);
        break;
      default:
        isInvalid = false;
        break;
    }

    setInvalidFields((prev) => ({ ...prev, [field.id]: isInvalid }));
    return isInvalid;
  };

  const handleInputChange = (e, field) => {
    const { id, value, type } = e.target;
    validation(value, field);
    setData((prevData) => ({
      ...prevData,
      [id]: type === "number" ? parseFloat(value) : value,
    }));
  };

  useEffect(() => {
    const isValidNow = !Object.values(invalidFields).some((isInvalid) => isInvalid);
    setIsValid(isValidNow);
  }, [invalidFields, setIsValid]);

  return { handleInputChange };
};
