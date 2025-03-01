import React, { useState, useEffect } from "react";
import "../info.css";

import { useTranslation } from "react-i18next";
import { useParams } from "react-router-dom";

import fermentingIngredientFieldsProvider from "./FermentingIngredientsComponents/helpers/fermentingIngredientFieldsProvider";
import { fetchData, apiEndpoints } from "../../Shared/api";

import ControlsCard from "../../Shared/ControlComponents/ControlsCard";
import FermentingIngredientQuantityCard from "./FermentingIngredientsComponents/FermentingIngredientQuantityCard";
import PieChartComponent from "../../Shared/PieChartComponent";
import { Button } from "react-bootstrap";
import UnitsList from "./FermentingIngredientsComponents/UnitsList";

const FermentingIngredientDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();

  const [ingredientData, setIngredientData] = useState({});
  const [chartAvailableData, setChartAvailableData] = useState([]);
  const [chartReservedData, setChartReservedData] = useState([]);

  useEffect(() => {
    fetchData(
      `${apiEndpoints.fermentingIngredientSummary}/${id}`,
      setIngredientData
    );
  }, []);

  useEffect(() => {
    setChartAvailableData([
      { name: "Stored", value: ingredientData.storedQuantity },
      { name: "Ordered", value: ingredientData.orderedQuantity },
    ]);
    setChartReservedData([
      {
        name: "Available",
        value: ingredientData.storedQuantity + ingredientData.orderedQuantity,
      },
      { name: "Reserved", value: ingredientData.reservedQuantity },
    ]);
  }, [ingredientData]);

  return (
    <div className="fermenting-ingredient-details_container">
      <h5>Details</h5>
      <h3>
        {ingredientData.name} [{ingredientData.unit}]
      </h3>
      <div className="fermenting-ingredient-details_buttons-container">
        <Button variant="dark">Usuń</Button>
      </div>
      <div className="fermenting-ingredient-chart_container">
        <div>
          <h3>Dostępne</h3>
          <PieChartComponent data={chartAvailableData} />
        </div>
        <div>
          <h3>Zarezerwowane</h3>
          <PieChartComponent data={chartReservedData} setOfColor={3} />
        </div>
      </div>
      <div className="fermenting-ingredient-card_container">
        <ControlsCard
          className="fermenting-ingredient-card-info_container"
          title={t("fermentingIngredient.infoTitle")}
          data={ingredientData}
          fields={fermentingIngredientFieldsProvider(t).infoFields.control}
          path={`${apiEndpoints.fermentingIngredientSummary}/${id}`}
          emptyMessage={t("fermentingIngredient.infoEmptyMsg")}
        />
        <FermentingIngredientQuantityCard
          className="fermenting-ingredient-quantity_container"
          title={t("fermentingIngredient.quantityTitle")}
          data={ingredientData}
          path={`${apiEndpoints.fermentingIngredientSummary}/${id}`}
          emptyMessage={t("fermentingIngredient.infoEmptyMsg")}
        />
        <UnitsList data={ingredientData} refreshPageData={() => {}} />
      </div>
    </div>
  );
};

export default FermentingIngredientDetails;
