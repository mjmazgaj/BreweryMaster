import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../../info.css";

import DynamicTable from "../../../../Shared/TableComponents/DynamicTable";
import ModalItemAction from "../../../../Shared/ModalComponents/ModalItemAction";
import { Button } from "react-bootstrap";
import modalFieldsProvider from "../../../../Shared/ModalComponents/helpers/modalFieldsProvider";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../../Shared/ModalComponents/ModalConfirmation";
import { dbhandler } from "../dbhandler";

const FermentingIngredientsSummary = () => {
  const { t } = useTranslation();

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  const [showItemAction, setShowItemAction] = useState(false);
  const [modalData, setModalData] = useState([]);
  const [action, setAction] = useState("summary");
  
  const { ingredients } = dbhandler();

  const handleDoubleClick = (item) => {
    setAction("summary");
    setModalData({ ...item });
    setShowItemAction(true);
  };

  const handleAddOnClick = () => {
    setAction("add");
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
        fields={modalFieldsProvider(t).ingredientsModalFields}
        data={modalData}
        setData={setModalData}
        show={showItemAction}
        setShow={setShowItemAction}
        setShowConfirmationModal={setShowConfirmationModal}
        action={action}
        setAction={setAction}
        itemName="Fermenting Ingredient"
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
