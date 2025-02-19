import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../info.css";

import DynamicTable from "../../../Shared/TableComponents/DynamicTable";
import ModalItemAction from "../../../Shared/ModalComponents/ModalItemAction";
import { Button } from "react-bootstrap";
import modalFieldsProvider from "../../../Shared/ModalComponents/helpers/modalFieldsProvider";

import { useFermentingIngredientsSummary } from "./helpers/useFermentingIngredientsSummary";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../Shared/ModalComponents/ModalConfirmation";
import ModalFormBasic from "../../../Shared/ModalComponents/ModalFormBasic";
import FermentingIngredientsFilter from "./FermentingIngredientsFilter";

const FermentingIngredientsSummary = () => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState([]);
  const [modalQuantityData, setModalQuantityData] = useState([]);

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

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);

  const [showItemAction, setShowItemAction] = useState(false);
  const [itemAction, setItemAction] = useState("summary");

  const [showModalForm, setShowModalForm] = useState(false);
  const [modalAction, setModalAction] = useState("Add");

  const [showQuantityModal, setShowQuantityModal] = useState(false);
  const [quantityAction, setQuantityAction] = useState({
    verb: "Add",
    area: "reservation",
  });

  const { handleDoubleClick, handleAddOnClick, refreshTableData } =
    useFermentingIngredientsSummary({
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
      <ModalItemAction
        fields={modalFieldsProvider(t).fermentingIngredientsModalReadOnlyFields}
        data={modalData}
        show={showItemAction}
        setShow={setShowItemAction}
        setShowConfirmationModal={setShowConfirmationModal}
        setShowQuantityModal={setShowQuantityModal}
        setShowModalForm={setShowModalForm}
        setModalAction={setModalAction}
        setQuantityAction={setQuantityAction}
        action={itemAction}
        setAction={setItemAction}
      />

      <ModalFormBasic
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

      <ModalFormBasic
        fields={modalFieldsProvider(t).quantityModalFields[quantityAction.area]}
        data={modalQuantityData}
        setData={setModalQuantityData}
        show={showQuantityModal}
        setShow={setShowQuantityModal}
        action={quantityAction.verb}
        itemName={`${quantityAction.verb} ${quantityAction.area} for ${modalData.name}`}
        path={`FermentingIngredient/${quantityAction.area}`}
        refreshTableData={refreshTableData}
      />

      <ModalConfirmation
        id={modalData.id}
        name={`${modalData.name} [${modalData.unit}]`}
        confirmationAction="delete"
        show={showConfirmationModal}
        setShow={setShowConfirmationModal}
        path="FermentingIngredient"
        refreshTableData={refreshTableData}
      />
    </div>
  );
};

export default FermentingIngredientsSummary;
