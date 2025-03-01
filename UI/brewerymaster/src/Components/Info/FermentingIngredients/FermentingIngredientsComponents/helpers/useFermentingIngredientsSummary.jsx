import { useState, useEffect } from "react";

import { fetchData, apiEndpoints } from "../../../../Shared/api";
import { useTranslation } from "react-i18next";

import { useNavigate } from "react-router-dom";

import modalFieldsProvider from "../../../../Shared/ModalComponents/helpers/modalFieldsProvider";
export const useFermentingIngredientsSummary = ({
  setData,
  setModalData,
  setShowModalForm,
  setFields,
  setFilterFields,
}) => {
  const { t } = useTranslation();
    const navigate = useNavigate();

  const [types, setTypes] = useState([]);
  const [units, setUnits] = useState([]);

  const handleDoubleClick = (item) => {
    navigate(`/FermentingIngredients/${item.id}`)
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

    setFields(() => ({
      control: modalFieldsProvider(t).fermentingIngredientsModalFields,
      dropdown: [
        {
          data: types,
          name: "typeId",
          label: t("name.brewery.type"),
        },
      ],
      checkBox: units.map((x) => ({ ...x, label: x.name })),
    }));

    setShowModalForm(true);
  };

  const refreshTableData = () =>
    fetchData(apiEndpoints.fermentingIngredientSummary, setData);

  useEffect(() => {
    refreshTableData();
    fetchData(apiEndpoints.entityUnit, setUnits);
    fetchData(apiEndpoints.fermentingIngredientType, setTypes);
  }, []);

  useEffect(() => {
    setFilterFields({
      control: modalFieldsProvider(t).fermentingIngredientsFilterFields,
      dropdown: [
        {
          data: types,
          name: "typeId",
          label: t("name.brewery.type"),
        },
        {
          data: units,
          name: "unitId",
          label: t("name.brewery.unit"),
        },
      ],
    });
  }, [types, units]);

  return {
    handleDoubleClick,
    handleAddOnClick,
    refreshTableData,
  };
};
