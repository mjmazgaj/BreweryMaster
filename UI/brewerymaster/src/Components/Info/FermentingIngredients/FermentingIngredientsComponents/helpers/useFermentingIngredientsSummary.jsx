import { useState, useEffect } from "react";

import { fetchData } from "../../../../Shared/api";
import { useTranslation } from "react-i18next";

import modalFieldsProvider from "../../../../Shared/ModalComponents/helpers/modalFieldsProvider";
export const useFermentingIngredientsSummary = ({
  setData,
  modalData,
  setModalData,
  setItemAction,
  setShowItemAction,
  setModalAction,
  setShowModalForm,
  setModalQuantityData,
  setFields,
  setFilterFields,
}) => {
  const { t } = useTranslation();
  
  const [types, setTypes] = useState([]);
  const [units, setUnits] = useState([]);
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
      unit: item.unit,
      units: [],
    });

    setFields(() =>(
      {
        control: modalFieldsProvider(t).fermentingIngredientsModalFields,
        dropdown: [
          {
            data: types,
            name: "typeId",
            label: "Types",
          }
        ],
        checkBox: units.map((x)=>({...x, label: x.name}))
      }
    ));

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

  const refreshTableData = () => fetchData("FermentingIngredient/Summary", setData);

  useEffect(() => {
    refreshTableData();
    fetchData(`entity/Unit`, setUnits);
    fetchData("FermentingIngredient/Type", setTypes);
  }, []);

  useEffect(() =>{
    setFilterFields({
      control:modalFieldsProvider(t).fermentingIngredientsFilterFields,
      dropdown:[
        {
          data: types,
          name: "typeId",
          label: "Types",
        },
        {
          data: units,
          name: "unitId",
          label: "Units",
        },
      ],
    });

  },[types, units]);

  return {
    handleDoubleClick,
    handleAddOnClick,
    refreshTableData
  };
};
