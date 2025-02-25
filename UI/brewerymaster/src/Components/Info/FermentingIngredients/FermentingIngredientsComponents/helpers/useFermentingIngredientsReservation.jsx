import { useEffect } from "react";

import { fetchData, apiEndpoints } from "../../../../Shared/api";

export const useFermentingIngredientsReservation = ({
  setModalData,
  setShowQuantityModal,
  setData,
}) => {
  const handleDoubleClick = (item) => {
    setModalData({ ...item });
    setShowQuantityModal(true);
  };

  const refreshTableData = () =>
    fetchData(apiEndpoints.fermentingIngredientReservation, setData);

  useEffect(() => {
    refreshTableData();
  }, [setData]);

  return {
    handleDoubleClick,
    refreshTableData,
  };
};
