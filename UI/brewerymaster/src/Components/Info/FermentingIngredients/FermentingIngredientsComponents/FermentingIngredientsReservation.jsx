import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../../info.css";

import DynamicTable from "../../../Shared/TableComponents/DynamicTable";
import ModalForm from "../../../Shared/ModalComponents/ModalForm";

import modalFieldsProvider from "../../../Shared/ModalComponents/helpers/modalFieldsProvider";

import { useFermentingIngredientsReservation } from "./helpers/useFermentingIngredientsReservation";

import { useTranslation } from "react-i18next";
import ModalConfirmation from "../../../Shared/ModalComponents/ModalConfirmation";

const FermentingIngredientsReservation = () => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState([]);
  const [data, setData] = useState([]);

  const [showConfirmationModal, setShowConfirmationModal] = useState(false);

  const [showQuantityModal, setShowQuantityModal] = useState(false);

  const { handleDoubleClick, refreshTableData } =
    useFermentingIngredientsReservation({
      setModalData,
      setShowQuantityModal,
      setData,
    });

  return (
    <div className="Fermenting-Ingredient-Reservation_container">
      <DynamicTable
        tableKey="fermentingIngredientReservation"
        tableTitle={t("name.brewery.fermentingIngredientReservations")}
        dataCategory="brewery"
        data={data}
        handleDoubleClick={handleDoubleClick}
      />

      <ModalForm
        fields={modalFieldsProvider(t).quantityModalFields["reservation"]}
        data={modalData}
        setData={setModalData}
        show={showQuantityModal}
        setShow={setShowQuantityModal}
        action="Edit"
        itemName={`reservation for ${modalData.name}`}
        path="FermentingIngredient/Reservation"
        refreshTableData={refreshTableData}
      />

      <ModalConfirmation
        id={modalData.id}
        name={modalData.name}
        confirmationAction="delete"
        show={showConfirmationModal}
        setShow={setShowConfirmationModal}
        path="FermentingIngredient/Reservation"
      />
    </div>
  );
};

export default FermentingIngredientsReservation;
