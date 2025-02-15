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
import ModalForm from "../../../Shared/ModalComponents/ModalForm";

const FermentingIngredientsSummary = () => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState([]);
  const [modalQuantityData, setModalQuantityData] = useState([]);
  
  const [data, setData] = useState([]);
  const [types, setTypes] = useState([]);

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);

  const [showItemAction, setShowItemAction] = useState(false);
  const [itemAction, setItemAction] = useState("summary");
  const[units, setUnits] = useState([]);

  const [showModalForm, setShowModalForm] = useState(false);
  const [modalAction, setModalAction] = useState("add");

  const [showQuantityModal, setShowQuantityModal] = useState(false);
  const [quantityAction, setQuantityAction] = useState({
    verb: "add",
    area: "reserve",
  });

  const {handleDoubleClick, handleAddOnClick} = useFermentingIngredientsSummary({
    setData,
    modalData,
    setModalData,
    setUnits,
    setTypes,
    setItemAction,
    setShowItemAction,
    setModalAction,
    setShowModalForm,
    setModalQuantityData,});

  return (
    <div className="Fermenting-Ingredient_container">
      {data && (
        <DynamicTable
          tableKey="fermentingIngredient"
          tableTitle="Fermenting Ingredients"
          dataCategory="brewery"
          data={data}
          handleDoubleClick={handleDoubleClick}
        />
      )}
      <Button variant="dark" onClick={handleAddOnClick}>
        Add Fermenting Ingredient
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
      <ModalForm
        fields={modalFieldsProvider(t).fermentingIngredientsModalFields}
        data={modalData}
        setData={setModalData}
        units={units}
        types={types}
        show={showModalForm}
        setShow={setShowModalForm}
        action={modalAction}
        setAction={setModalAction}
        itemName="Fermenting Ingredient"
      />
      
      <ModalFormBasic
          fields={modalFieldsProvider(t).quantityModalFields[quantityAction.area]}
          data={modalQuantityData}
          setData={setModalQuantityData}
          show={showQuantityModal}
          setShow={setShowQuantityModal}
          action={quantityAction.verb}
          itemName={`${quantityAction.area == "reserve" ? "reservation" : "order"} for ${modalData.name}`}
          path={`FermentingIngredient/${quantityAction.area == "reserve" ? "Reservation" : "Order"}`}
        />

      <ModalConfirmation
        id={modalData.id}
        name={modalData.name}
        confirmationAction="delete"
        show={showConfirmationModal}
        setShow={setShowConfirmationModal}
      />
    </div>
  );
};

export default FermentingIngredientsSummary;
