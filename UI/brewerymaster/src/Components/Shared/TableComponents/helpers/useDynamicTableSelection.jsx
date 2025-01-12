import { useState } from "react";

export const useDynamicTableSelection = (setShowQuantityModal) => {
  const [modalData, setModalData] = useState([]);
  
  const handleDoubleClick = (item) => {
    setModalData({ ...item});
    setShowQuantityModal(true);
  };
  
  return {
    handleDoubleClick,
    modalData
  };
};