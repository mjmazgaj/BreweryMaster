export const useModalFormBasic = ({
  setData,
  setShow,
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

  return {
    handleClose,
    handleCheckBox,
    handleSelectChange,
    handleDateChange,
  };
};
