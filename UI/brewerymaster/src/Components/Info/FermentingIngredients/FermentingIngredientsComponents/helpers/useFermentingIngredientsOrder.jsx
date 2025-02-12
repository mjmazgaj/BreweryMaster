import { useEffect } from "react";
import { fetchData } from "../../../../Shared/api";

export const useFermentingIngredientsOrder = ({setModalData, setData, setShowQuantityModal}) => {

  const handleDoubleClick = (item) => {
    setModalData({ ...item });
    setShowQuantityModal(true);
  };

    useEffect(() => {
      fetchData("FermentingIngredient/Order", setData);
    }, []);

  return {
    handleDoubleClick
  };
};