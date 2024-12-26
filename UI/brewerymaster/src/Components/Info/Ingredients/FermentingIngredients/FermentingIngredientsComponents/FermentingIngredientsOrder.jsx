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

const FermentingIngredientsOrder = () => {
  const { t } = useTranslation();

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  const [showItemAction, setShowItemAction] = useState(false);
  const [modalData, setModalData] = useState([]);
  const [action, setAction] = useState("default");

  const { ingredientsOrdered } = dbhandler();

  const handleDoubleClick = (item) => {
    setAction("default");
    setModalData({ ...item });
    setShowItemAction(true);
  };

  const handleAddOnClick = () => {
    setAction("add");
    setModalData(null);
    setShowItemAction(true);
  };

  return (
    <div className="Fermenting-Ingredient-Order_container">
      <DynamicTable
        tableKey="fermentingIngredientOrder"
        tableTitle="Fermenting Ingredient order"
        data={ingredientsOrdered}
        handleDoubleClick={handleDoubleClick}
      />
      <Button variant="dark" onClick={handleAddOnClick}>
        Add Fermenting Ingredient order
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

export default FermentingIngredientsOrder;
