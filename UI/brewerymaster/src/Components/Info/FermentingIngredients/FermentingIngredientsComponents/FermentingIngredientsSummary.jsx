import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../info.css";

import DynamicTable from "../../../Shared/TableComponents/DynamicTable";
import ModalItemAction from "../../../Shared/ModalComponents/ModalItemAction";
import { Button } from "react-bootstrap";
import modalFieldsProvider from "../../../Shared/ModalComponents/helpers/modalFieldsProvider";
import { fetchSummaryData, fetchTypes } from "../../api";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../Shared/ModalComponents/ModalConfirmation";
import ModalQuantity from "../../../Shared/ModalComponents/ModalQuantity";
import ModalForm from "../../../Shared/ModalComponents/ModalForm";

import {removeFields} from "../../../Shared/helpers/useObjectHelper";

const FermentingIngredientsSummary = () => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState([]);
  const [modalItemData, setModalItemData] = useState([]);
  const [modalFormData, setModalFormData] = useState([]);
  
  const [data, setData] = useState([]);
  const [types, setTypes] = useState([]);

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);

  const [showItemAction, setShowItemAction] = useState(false);
  const [itemAction, setItemAction] = useState("summary");

  const [showModalForm, setShowModalForm] = useState(false);
  const [modalAction, setModalAction] = useState("add");

  const [showQuantityModal, setShowQuantityModal] = useState(false);
  const [quantityAction, setQuantityAction] = useState({
    verb: "add",
    area: "reserve",
  });

  const handleDoubleClick = (item) => {
    setItemAction("summary");
    setModalItemData(removeFields(item, ["typeId"]));
    setModalFormData(removeFields(item, ["typeName"]));
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
    });
  };

  const handleAddOnClick = () => {
    clear();
    setModalAction("add");
    setShowModalForm(true);
  };

  useEffect(() => {
    fetchSummaryData("FermentingIngredient", setData);
    fetchTypes("FermentingIngredient", setTypes);
  }, [modalData]);

  return (
    <div className="Fermenting-Ingredient_container">
      {data && (
        <DynamicTable
          tableKey="fermentingIngredient"
          tableTitle="Fermenting Ingredient"
          data={data}
          handleDoubleClick={handleDoubleClick}
        />
      )}
      <Button variant="dark" onClick={handleAddOnClick}>
        Add Fermenting Ingredient
      </Button>
      <ModalItemAction
        fields={modalFieldsProvider(t).fermentingIngredientsModalReadOnlyFields}
        data={modalItemData}
        types={types}
        show={showItemAction}
        setShow={setShowItemAction}
        setShowConfirmationModal={setShowConfirmationModal}
        setShowQuantityModal={setShowQuantityModal}
        setShowModalForm={setShowModalForm}
        setModalAction={setModalAction}
        setQuantityAction={setQuantityAction}
        action={itemAction}
        setAction={setItemAction}
        itemName="Fermenting Ingredient"
      />
      <ModalForm
        fields={modalFieldsProvider(t).fermentingIngredientsModalFields}
        data={modalFormData}
        setData={setModalFormData}
        types={types}
        show={showModalForm}
        setShow={setShowModalForm}
        action={modalAction}
        setAction={setModalAction}
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
