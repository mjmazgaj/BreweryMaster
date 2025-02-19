import { useEffect } from "react";
import { fetchData } from "../../../../Shared/api";

export const useFermentingIngredientsOrder = ({
  setModalData,
  setData,
  setShowQuantityModal,
}) => {
  const handleDoubleClick = (item) => {
    setModalData({
      id: item.id,
      name: item.name,
      quantity: item.orderedQuantity,
      expectedDate: item.expectedDate,
      info: item.info,
    });
    setShowQuantityModal(true);
  };

  const refreshTableData = () =>
    fetchData("FermentingIngredient/Order", setData);

  useEffect(() => {
    refreshTableData();
  }, [setData]);

  return {
    handleDoubleClick,
    refreshTableData,
  };
};
