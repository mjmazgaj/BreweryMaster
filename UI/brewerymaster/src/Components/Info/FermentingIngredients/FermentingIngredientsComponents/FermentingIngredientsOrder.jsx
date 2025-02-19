import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../info.css";

import DynamicTable from "../../../Shared/TableComponents/DynamicTable";
import ModalForm from "../../../Shared/ModalComponents/ModalForm";
import modalFieldsProvider from "../../../Shared/ModalComponents/helpers/modalFieldsProvider";

import { useFermentingIngredientsOrder } from "./helpers/useFermentingIngredientsOrder";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../Shared/ModalComponents/ModalConfirmation";

const FermentingIngredientsOrder = () => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState([]);
  const [data, setData] = useState([]);

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);

  const [showQuantityModal, setShowQuantityModal] = useState(false);

  const { handleDoubleClick, refreshTableData } = useFermentingIngredientsOrder(
    {
      setModalData,
      setData,
      setShowQuantityModal,
    }
  );

  return (
    <div className="Fermenting-Ingredient-Order_container">
      <DynamicTable
        tableKey="fermentingIngredientOrder"
        tableTitle="Fermenting Ingredient Orders"
        dataCategory="brewery"
        data={data}
        handleDoubleClick={handleDoubleClick}
      />

      <ModalForm
        fields={modalFieldsProvider(t).quantityModalFields["order"]}
        data={modalData}
        setData={setModalData}
        show={showQuantityModal}
        setShow={setShowQuantityModal}
        action="Edit"
        itemName={`order for ${modalData.name}`}
        path="FermentingIngredient/Order"
        refreshTableData={refreshTableData}
      />

      <ModalConfirmation
        id={modalData.id}
        name={modalData.name}
        confirmationAction="delete"
        show={showConfirmationModal}
        setShow={setShowConfirmationModal}
        path="FermentingIngredient/Order"
      />
    </div>
  );
};

export default FermentingIngredientsOrder;
