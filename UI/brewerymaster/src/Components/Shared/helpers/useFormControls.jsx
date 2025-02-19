import { useEffect } from "react";

export const useFormControls = ({
  setData,
  setIsValid,
  invalidFields,
  setInvalidFields,
}) => {
  const validateNumber = (value, validation, id) => {
    const isInvalid = validation
      ? value > validation.max || value < validation.min
      : false;
    setInvalidFields((prev) => ({ ...prev, [id]: isInvalid }));
  };

  const validateText = (value, validation, id) => {
    const isInvalid = validation ? value.length > validation.maxLength : false;
    setInvalidFields((prev) => ({ ...prev, [id]: isInvalid }));
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
        setInvalidFields((prev) => ({ ...prev, [field.id]: false }));
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

  useEffect(() => {
    const isValidNow = !Object.values(invalidFields).some(
      (isInvalid) => isInvalid
    );
    setIsValid(isValidNow);
  }, [invalidFields, setIsValid]);

  return {
    handleInputChange,
  };
};
