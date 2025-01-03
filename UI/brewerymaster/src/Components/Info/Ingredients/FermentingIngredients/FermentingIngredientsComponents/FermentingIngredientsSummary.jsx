import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../../info.css";

import DynamicTable from "../../../../Shared/TableComponents/DynamicTable";
import ModalItemAction from "../../../../Shared/ModalComponents/ModalItemAction";
import { Button } from "react-bootstrap";
import modalFieldsProvider from "../../../../Shared/ModalComponents/helpers/modalFieldsProvider";
import {fetchSummaryData} from "../../api";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../../Shared/ModalComponents/ModalConfirmation";
import ModalQuantity from "../../../../Shared/ModalComponents/ModalQuantity";

const FermentingIngredientsSummary = () => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState([]);
  const [data, setData] = useState([]);
  
  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  
  const [showItemAction, setShowItemAction] = useState(false);
  const [itemAction, setItemAction] = useState("summary");
  
  const [showQuantityModal, setShowQuantityModal] = useState(false);
  const [quantityAction, setQuantityAction] = useState({
    verb: "add",
    area: "reserve"
  });

  const handleDoubleClick = (item) => {
    setItemAction("summary");
    setModalData({ ...item });
    setShowItemAction(true);
  };

  const clear = () =>{
    setModalData({
      "id": 0,
      "type": "",
      "name": "",
      "percentage": "",
      "extraction": "",
      "ebc": "",
      "quantity": "",
      "total": 13
  });
  }

  const handleAddOnClick = () => {
    clear();
    setItemAction("add");
    setShowItemAction(true);
  };

    useEffect(() => {
      fetchSummaryData("FermentingIngredient", setData);
    }, []);
  
  return (
    <div className="Fermenting-Ingredient_container">
      {data ? (
        <DynamicTable
          tableKey="fermentingIngredient"
          tableTitle="Fermenting Ingredient"
          data={data}
          handleDoubleClick={handleDoubleClick}
        />
      ) : (
        <></>
      )}
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
        fields={modalFieldsProvider(t).quantityModalFields[quantityAction.area]}
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
