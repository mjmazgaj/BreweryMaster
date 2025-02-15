import { useEffect } from "react";

import { fetchData } from "../../../../Shared/api";

export const useFermentingIngredientsSummary = ({
  setData,
  modalData,
  setModalData,
  setUnits,
  setTypes,
  setItemAction,
  setShowItemAction,
  setModalAction,
  setShowModalForm,
  setModalQuantityData,
}) => {
  const handleDoubleClick = (item) => {
    setItemAction("summary");

    setModalData({
      id: item.id,
      typeId: item.typeId,
      typeName: item.typeName,
      name: item.name,
      percentage: item.percentage,
      extraction: item.extraction,
      ebc: item.ebc,
      info: item.info,
      units: [],
    });

    setModalQuantityData({
      name: item.name,
      fermentingIngredientUnitId: item.id,
    });
    setShowItemAction(true);
  };

  const clear = () => {
    setModalData({
      id: 0,
      type: "",
      name: "",
      percentage: "",
      extraction: "",
      ebc: "",
      quantity: "",
      total: 13,
      units: [],
    });
  };

  const handleAddOnClick = () => {
    clear();
    setModalAction("add");
    setShowModalForm(true);
  };

  useEffect(() => {
    fetchData("FermentingIngredient/Summary", setData);
  }, [modalData]);

  useEffect(() => {
    fetchData(`entity/Unit`, setUnits);
    fetchData("FermentingIngredient/Type", setTypes);
  }, []);

  return {
    handleDoubleClick,
    handleAddOnClick,
  };
};
