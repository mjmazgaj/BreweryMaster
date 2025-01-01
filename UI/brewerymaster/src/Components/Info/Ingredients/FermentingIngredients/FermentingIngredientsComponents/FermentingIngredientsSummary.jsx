import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../../info.css";

import DynamicTable from "../../../../Shared/TableComponents/DynamicTable";
import ModalItemAction from "../../../../Shared/ModalComponents/ModalItemAction";
import { Button } from "react-bootstrap";
import modalFieldsProvider from "../../../../Shared/ModalComponents/helpers/modalFieldsProvider";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../../Shared/ModalComponents/ModalConfirmation";
import ModalQuantity from "../../../../Shared/ModalComponents/ModalQuantity";
import { dbhandler } from "../dbhandler";

const FermentingIngredientsSummary = () => {
  const { t } = useTranslation();

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  const [showItemAction, setShowItemAction] = useState(false);
  const [showQuantityModal, setShowQuantityModal] = useState(false);
  const [modalData, setModalData] = useState([]);
  const [itemAction, setItemAction] = useState("summary");
  const [quantityAction, setQuantityAction] = useState("reserve");
  
  const { ingredients } = dbhandler();

  const handleDoubleClick = (item) => {
    setItemAction("summary");
    setModalData({ ...item });
    setShowItemAction(true);
  };

  const handleAddOnClick = () => {
    setItemAction("add");
    setModalData(null);
    setShowItemAction(true);
  };

  return (
    <div className="Fermenting-Ingredient_container">
      <DynamicTable
        tableKey="fermentingIngredient"
        tableTitle="Fermenting Ingredient"
        data={ingredients}
        handleDoubleClick={handleDoubleClick}
      />
      <Button variant="dark" onClick={handleAddOnClick}>
        Add Fermenting Ingredient
      </Button>
      <ModalItemAction
        fields={modalFieldsProvider(t).fermentingIngredientsModalFields}
        data={modalData}
        setData={setModalData}
        show={showItemAction}
        setShow={setShowItemAction}
        setShowConfirmationModal={setShowConfirmationModal}
        setShowQuantityModal={setShowQuantityModal}
        setQuantityAction={setQuantityAction}
        action={itemAction}
        setAction={setItemAction}
        itemName="Fermenting Ingredient"
      />
      <ModalQuantity
        fields={modalFieldsProvider(t).quantityModalFields[quantityAction]}
        modalData={modalData}
        show={showQuantityModal}
        setShow={setShowQuantityModal}
        action={quantityAction}
        isEmpty={true}
      />
      <ModalConfirmation
        data={modalData}
        confirmationAction="delete"
        show={showConfirmationModal}
        setShow={setShowConfirmationModal}
      />
    </div>
  );
};

export default FermentingIngredientsSummary;
