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
  useEffect(() => {
    fetchData("FermentingIngredient/Reservation", setData);
  }, []);

  return {
    handleDoubleClick,
  };
};
