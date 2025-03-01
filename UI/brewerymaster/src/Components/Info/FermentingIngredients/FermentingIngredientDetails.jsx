import React, { useState } from "react";
import "../info.css";

import { useTranslation } from "react-i18next";
import { useParams } from "react-router-dom";

import fermentingIngredientFieldsProvider from "./FermentingIngredientsComponents/helpers/fermentingIngredientFieldsProvider";
import { apiEndpoints } from "../../Shared/api";

import ControlsCard from "../../Shared/ControlComponents/ControlsCard";
import FermentingIngredientQuantityCard from "./FermentingIngredientsComponents/FermentingIngredientQuantityCard";
import PieChartComponent from "../../Shared/PieChartComponent";
import { Button } from "react-bootstrap";
import UnitsList from "./FermentingIngredientsComponents/UnitsList";
import ModalFormBasic from "../../Shared/ModalComponents/ModalFormBasic";

import { useFermentingIngredientsDetails } from "./FermentingIngredientsComponents/helpers/useFermentingIngredientsDetails";

const FermentingIngredientDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();

  const [ingredientData, setIngredientData] = useState({});
  const [chartAvailableData, setChartAvailableData] = useState([]);

  const [modalData, setModalData] = useState({});
  const [showEditInfoModal, setShowEditInfoModal] = useState(false);

  const [modalFields, setModalFields] = useState({});

  const { handleEditInfoOnClick, editInfoModalObject } =
    useFermentingIngredientsDetails({
      setModalFields,
      setShowEditInfoModal,
      setModalData,
      ingredientData,
      setIngredientData,
      setChartAvailableData,
      id,
    });

  return (
    <div className="fermenting-ingredient-details_container">
      <h5>{t("name.general.details")}</h5>
      <h3>
        {ingredientData.name} [{ingredientData.unit}]
      </h3>
      <div className="fermenting-ingredient-details_buttons-container">
        <Button variant="dark" onClick={handleEditInfoOnClick}>
          {t("button.delete")}
        </Button>
      </div>
      <div className="fermenting-ingredient-card_container">
        <div className="fermenting-ingredient-BasicInfo_container">
          <ControlsCard
            className="fermenting-ingredient-card-info_container"
            title={t("fermentingIngredient.infoTitle")}
            data={ingredientData}
            fields={fermentingIngredientFieldsProvider(t).infoFields.control}
            path={`${apiEndpoints.fermentingIngredientSummary}/${id}`}
            emptyMessage={t("fermentingIngredient.infoEmptyMsg")}
            handleEdit={handleEditInfoOnClick}
          />
          <UnitsList data={ingredientData} refreshPageData={() => {}} />
        </div>
        <div className="fermenting-ingredient-AdditionalInfo_container">
          <h4>{t("name.general.details")}</h4>
          <PieChartComponent data={chartAvailableData} />
          <FermentingIngredientQuantityCard
            className="fermenting-ingredient-quantity_container"
            title={t("fermentingIngredient.quantityTitle")}
            data={ingredientData}
            path={`${apiEndpoints.fermentingIngredientSummary}/${id}`}
            emptyMessage={t("fermentingIngredient.infoEmptyMsg")}
          />
        </div>

        <ModalFormBasic
          fields={modalFields}
          data={modalData}
          setData={setModalData}
          show={showEditInfoModal}
          setShow={setShowEditInfoModal}
          modalCustomizationObject={editInfoModalObject}
        />
      </div>
    </div>
  );
};

export default FermentingIngredientDetails;
