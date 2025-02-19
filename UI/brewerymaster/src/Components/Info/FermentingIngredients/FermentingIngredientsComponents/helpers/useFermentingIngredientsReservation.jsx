import { useEffect } from "react";

import { fetchData } from "../../../../Shared/api";

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
    fetchData("FermentingIngredient/Reservation", setData);

  useEffect(() => {
    refreshTableData();
  }, [setData]);

  return {
    handleDoubleClick,
    refreshTableData,
  };
};
