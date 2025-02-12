import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../info.css";

import DynamicTable from "../../../Shared/TableComponents/DynamicTable";
import ModalFormBasic from "../../../Shared/ModalComponents/ModalFormBasic";
import modalFieldsProvider from "../../../Shared/ModalComponents/helpers/modalFieldsProvider";

import {useFermentingIngredientsOrder} from "./helpers/useFermentingIngredientsOrder";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../Shared/ModalComponents/ModalConfirmation";

const FermentingIngredientsOrder = () => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState([]);
  const [data, setData] = useState([]);

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);

  const [showQuantityModal, setShowQuantityModal] = useState(false);

  const {handleDoubleClick} = useFermentingIngredientsOrder({setModalData, setData, setShowQuantityModal})

  return (
    <div className="Fermenting-Ingredient-Order_container">
      <DynamicTable
        tableKey="fermentingIngredientOrder"
        tableTitle="Fermenting Ingredient Orders"
        dataCategory="brewery"
        data={data}
        handleDoubleClick={handleDoubleClick}
      />

      <ModalFormBasic
          fields={modalFieldsProvider(t).quantityModalFields["order"]}
          data={modalData}
          setData={setModalData}
          show={showQuantityModal}
          setShow={setShowQuantityModal}
          action="edit"
          itemName={`order for ${modalData.name}`}
          path="FermentingIngredient/Order"
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
