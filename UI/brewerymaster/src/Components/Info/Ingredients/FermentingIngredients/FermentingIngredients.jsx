import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "../../info.css";

import DynamicTable from "../../../Shared/TableComponents/DynamicTable";
import ModalItemAction from "../../../Shared/ModalComponents/ModalItemAction";
import { Button } from "react-bootstrap";
import modalFieldsProvider from "../../../Shared/ModalComponents/helpers/modalFieldsProvider";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../Shared/ModalComponents/ModalConfirmation";
const FermentingIngredients = () => {
  const { t } = useTranslation();

  const [ingredients, setIngredients] = useState([
    {
      id: 1,
      type: "Grain",
      name: "Viking Pilsner malt",
      quantity: 3,
      reserved: 3,
      ordered: 3,
      percentage: 62.5,
      extraction: 82,
      ebc: 4,
    },
    {
      id: 2,
      type: "Grain",
      name: "Strzegom Monachijski typ II",
      quantity: 1,
      reserved: 3,
      ordered: 3,
      percentage: 20.8,
      extraction: 79,
      ebc: 22,
    },
    {
      id: 3,
      type: "Grain",
      name: "Strzegom Karmel 150",
      quantity: 0.5,
      reserved: 3,
      ordered: 3,
      percentage: 10.4,
      extraction: 75,
      ebc: 150,
    },
    {
      id: 4,
      type: "Grain",
      name: "Oats, Flaked",
      quantity: 0.3,
      reserved: 3,
      ordered: 3,
      percentage: 6.3,
      extraction: 80,
      ebc: 2,
    },
  ]);

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  const [showItemAction, setShowItemAction] = useState(false);
  const [modalData, setModalData] = useState([]);
  const [action, setAction] = useState("default");

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
    <div className="Info_container">
      <ToastContainer />
      <DynamicTable
        tableKey="fermentingIngredientSummary"
        tableTitle="Fermenting Ingredient summary"
        data={ingredients}
        handleDoubleClick={handleDoubleClick}
      />
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
      <Button variant="dark" onClick={handleAddOnClick}>
        Add
      </Button>
    </div>
  );
};

export default FermentingIngredients;
