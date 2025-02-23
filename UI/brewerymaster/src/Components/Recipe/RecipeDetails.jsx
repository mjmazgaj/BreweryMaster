import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Button, Card } from "react-bootstrap";

import { useTranslation } from "react-i18next";
import { fetchData } from "../Shared/api";

import fieldsProvider from "./RecipeComponents/helpers/fieldsProvider";
import "./recipe.css";
import "bootstrap/dist/css/bootstrap.min.css";
import "./recipe.css";
import DynamicTable from "../Shared/TableComponents/DynamicTable";
import ControlsCard from "../Shared/ControlComponents/ControlsCard";

const RecipeDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();
  const navigate = useNavigate();

  const [data, setData] = useState({});

  const handleButton = () => {
    navigate("/Recipe");
  };

  useEffect(() => {
    fetchData(`Recipe/${id}`, setData);
  }, []);

  return (
    <div className="recipe-details_container">
      <Button variant="dark" onClick={handleButton}>
        {t("button.back")}
      </Button>
      <h4>{t("recipe.detailTitle")}:</h4>
      <h2>{data?.generalInfo?.name}</h2>
      {data.info && (
        <Card className="recipe-info_container">
          <Card.Header>
            <h3>{t("name.general.describtion")}</h3>
          </Card.Header>
          <Card.Text>{data.info}</Card.Text>
        </Card>
      )}
      <div className="recipe-controls_container">
        <ControlsCard
          className="recipe-controls_general-info"
          title={t("name.general.summary")}
          data={data?.generalInfo}
          fields={fieldsProvider(t).recipeGeneralInfoFields.control}
          path="User"
          emptyMessage="Batch Info can't be loaded"
        />
        <ControlsCard
          className="recipe-controls_batch-info"
          title={t("recipe.batchInfo")}
          data={data?.batchInfo}
          fields={fieldsProvider(t).recipeBatchInfoFields.control}
          path="User"
          emptyMessage="Batch Info can't be loaded"
        />
        <ControlsCard
          className="recipe-controls_mash-info"
          title={t("recipe.mashInfo")}
          data={data?.mashInfo}
          fields={fieldsProvider(t).recipeMashInfoFields.control}
          path="User"
          emptyMessage="Mash Info can't be loaded"
        />
      </div>
      <div>
        <DynamicTable
          tableKey="fermentingIngredients"
          tableTitle={t("name.brewery.fermentingIngredients")}
          dataCategory="brewery"
          data={data?.fermentingIngredients}
          handleDoubleClick={() => {}}
        />
        <DynamicTable
          tableKey="hops"
          tableTitle={t("name.brewery.hops")}
          dataCategory="brewery"
          data={data?.hops}
          handleDoubleClick={() => {}}
        />
        <DynamicTable
          tableKey="yeast"
          tableTitle={t("name.brewery.yeast")}
          dataCategory="brewery"
          data={data?.yeast}
          handleDoubleClick={() => {}}
        />
      </div>
    </div>
  );
};

export default RecipeDetails;
