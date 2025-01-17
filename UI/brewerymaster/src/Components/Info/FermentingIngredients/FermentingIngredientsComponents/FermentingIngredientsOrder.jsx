import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../info.css";

import DynamicTable from "../../../Shared/TableComponents/DynamicTable";
import ModalQuantity from "../../../Shared/ModalComponents/ModalQuantity";
import modalFieldsProvider from "../../../Shared/ModalComponents/helpers/modalFieldsProvider";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../Shared/ModalComponents/ModalConfirmation";
import { dbhandler } from "../dbhandler";

const FermentingIngredientsOrder = () => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState([]);

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);

  const [showQuantityModal, setShowQuantityModal] = useState(false);
  const [quantityAction, setQuantityAction] = useState({
      verb: "edit",
      area: "order"
    });

  const { ingredientsOrdered } = dbhandler();

  const handleDoubleClick = (item) => {
    setModalData({ ...item });
    setShowQuantityModal(true);
  };

  return (
    <div className="Fermenting-Ingredient-Order_container">
      <DynamicTable
        tableKey="fermentingIngredientOrder"
        tableTitle="Fermenting Ingredient order"
        data={ingredientsOrdered}
        handleDoubleClick={handleDoubleClick}
      />
      <ModalQuantity
        fields={modalFieldsProvider(t).quantityModalFields[quantityAction.area]}
        modalData={modalData}
        show={showQuantityModal}
        setShow={setShowQuantityModal}
        action={quantityAction}
        isEmpty={false}
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

export default FermentingIngredientsOrder;
