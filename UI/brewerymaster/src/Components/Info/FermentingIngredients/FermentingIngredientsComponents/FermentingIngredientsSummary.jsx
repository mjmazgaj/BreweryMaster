import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../info.css";

import DynamicTable from "../../../Shared/TableComponents/DynamicTable";
import { Button } from "react-bootstrap";

import { useFermentingIngredientsSummary } from "./helpers/useFermentingIngredientsSummary";

import { useTranslation } from "react-i18next";
import ModalForm from "../../../Shared/ModalComponents/ModalForm";
import FermentingIngredientsFilter from "./FermentingIngredientsFilter";

const FermentingIngredientsSummary = () => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState([]);

  const [data, setData] = useState([]);
  const [fields, setFields] = useState({
    control: [],
    dropdown: [],
    checkBox: [],
  });
  const [filterFields, setFilterFields] = useState({
    control: [],
    dropdown: [],
  });

  const [showModalForm, setShowModalForm] = useState(false);
  const [modalAction, setModalAction] = useState("Add");

  const { handleDoubleClick, handleAddOnClick, refreshTableData } =
    useFermentingIngredientsSummary({
      setData,
      setModalData,
      setShowModalForm,
      setFields,
      setFilterFields,
    });

  return (
    <div className="Fermenting-Ingredient_container">
      <FermentingIngredientsFilter
        fields={filterFields}
        setTableData={setData}
      />

      {data && (
        <DynamicTable
          tableKey="fermentingIngredient"
          tableTitle={t("name.brewery.fermentingIngredients")}
          dataCategory="brewery"
          data={data}
          handleDoubleClick={handleDoubleClick}
        />
      )}
      <Button variant="dark" onClick={handleAddOnClick}>
        {t("button.add")}
      </Button>

      <ModalForm
        fields={fields}
        data={modalData}
        setData={setModalData}
        show={showModalForm}
        setShow={setShowModalForm}
        action={modalAction}
        setAction={setModalAction}
        itemName={t("name.brewery.fermentingIngredient")}
        path="FermentingIngredient"
        refreshTableData={refreshTableData}
      />
    </div>
  );
};

export default FermentingIngredientsSummary;
