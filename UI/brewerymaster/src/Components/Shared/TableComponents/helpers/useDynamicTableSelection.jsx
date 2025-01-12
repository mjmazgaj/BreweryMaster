import { useState } from "react";

export const useDynamicTableSelection = (data, setData, selectedData, setSelectedData) => {
  const [modalData, setModalData] = useState(null);
  
  const handleDoubleClick = (item) => {
    setModalData({ ...item});
  };

  const handleConfirmQuantity = (quantity) => {
    if (!modalData) return;

    const updatedData = data.map((item) =>
      item.id === modalData.id
        ? { 
          ...item, 
          reservedQuantity: item.reservedQuantity + quantity, 
          totalQuantity: item.totalQuantity - quantity 
        }
        : item
    );

    const existingSelected = selectedData.find(
      (item) => item.id === modalData.id
    );

    const { totalQuantity, storedQuantity, orderedQuantity, reservedQuantity,  ...selectedModalData } = modalData;

    let updatedSelected;
    if (existingSelected) {
      updatedSelected = selectedData.map((item) =>
        item.id === selectedModalData.id
          ? { 
            ...item, 
            reservedQuantity: item.reservedQuantity + quantity, 
            totalQuantity: item.totalQuantity - quantity 
          }
          : item
      );
    } else {
      updatedSelected = [
        ...selectedData,
        { ...selectedModalData, quantity },
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