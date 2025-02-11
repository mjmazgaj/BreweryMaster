import { useTranslation } from "react-i18next";

export const useModalRecipeQuantity = ({
  quantityData,
  setQuantityData,
  setSelectedData,
  setShow,
  action,
}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
    clear();
  };

  const clear = () => {
    setQuantityData({
      id: 0,
      name: "",
      quantity: 0,
      description: "",
    });
  }
  
  const updateField = (id, updatedField) => {
    setSelectedData((prevData) => {
      if (prevData[id]) {
        return {
          ...prevData,
          [id]: { ...prevData[id], ...updatedField },
        };
      } else {
        return {
          ...prevData,
          [id]: { ...updatedField },
        };
      }
    });
  };

  const handleAddIngredient = (quantityData) => {
    setShow(false);
    clear();
    console.log("Add ingredient");
    console.log(quantityData);
    
    const newData = {
      quantity: quantityData.quantity, 
      description: quantityData.description
    }

    updateField(quantityData.id, newData)
  };

  const actionCases = {
    addingredient: {
      title: `Add ingredient ${quantityData ? quantityData.name : ""}`,
      function: handleAddIngredient,
      isReadOnly: true,
    },
  };

  let actionObject = actionCases[`${action.verb}${action.area}`];

  return {
    handleClose,
    actionObject,
  };
};
