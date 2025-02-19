export const useModalForm = ({ setData }) => {
  const handleCheckBox = (name, isChecked) => {
    setData((prevData) => ({
      ...prevData,
      [name]: !isChecked,
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

  return {
    handleCheckBox,
    handleSelectChange,
    handleDateChange,
  };
};
