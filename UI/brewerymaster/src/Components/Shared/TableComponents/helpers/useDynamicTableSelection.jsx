import { useState } from "react";

export const useDynamicTableSelection = (data, setData, selectedData, setSelectedData) => {
  const [modalData, setModalData] = useState(null);
  
  const handleDoubleClick = (item) => {
    setModalData({ ...item, maxQuantity: item.quantity });
  };

  const handleConfirmQuantity = (quantity) => {
    if (!modalData) return;

    const updatedData = data.map((item) =>
      item.id === modalData.id
        ? { ...item, quantity: item.quantity - quantity }
        : item
    );

    const existingSelected = selectedData.find(
      (item) => item.id === modalData.id
    );

    let updatedSelected;
    if (existingSelected) {
      updatedSelected = selectedData.map((item) =>
        item.id === modalData.id
          ? { ...item, quantity: item.quantity + quantity }
          : item
      );
    } else {
      updatedSelected = [
        ...selectedData,
        { ...modalData, quantity },
      ];
    }

    setData(updatedData);
    setSelectedData(updatedSelected);
    setModalData(null);
  };

  return {
    handleDoubleClick,
    modalData,
    handleConfirmQuantity,
    setModalData
  };
};