import { useEffect } from "react";
import { fetchData, apiEndpoints } from "../../../../Shared/api";

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
    fetchData(apiEndpoints.fermentingIngredientOrder, setData);

  useEffect(() => {
    refreshTableData();
  }, [setData]);

  return {
    handleDoubleClick,
    refreshTableData,
  };
};
