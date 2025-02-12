import { useEffect } from "react";
import { fetchData } from "../../../../Shared/api";

export const useFermentingIngredientsOrder = ({setModalData, setData, setShowQuantityModal}) => {

  const handleDoubleClick = (item) => {
    setModalData({
        id: item.id,
        name: item.name,
        quantity: item.orderedQuantity,
        expectedDate: item.expectedDate,
        info: item.info
     });
    setShowQuantityModal(true);
  };

    useEffect(() => {
      fetchData("FermentingIngredient/Order", setData);
    }, []);

  return {
    handleDoubleClick
  };
};