import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Button } from "react-bootstrap";

import { useTranslation } from "react-i18next";
import { fetchData } from "../Shared/api";

import fieldsProvider from "./RecipeComponents/helpers/fieldsProvider";
import "./recipe.css"
import "bootstrap/dist/css/bootstrap.min.css";
import "react-toastify/dist/ReactToastify.css";
import "./recipe.css";
import FormControlsReadOnly from "../Shared/FormControlsReadOnly";
import DynamicTable from "../Shared/TableComponents/DynamicTable";

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
        Return
      </Button>
      <h4>Szczegóły na temat receputry:</h4>
      <h2>{data?.generalInfo?.name}</h2>
      <div className="recipe-controls_container">
        <div className="recipe-controls_general-info">
          <h3>Genarl Info</h3>
          <FormControlsReadOnly
            fields={fieldsProvider(t).recipeGeneralInfoFields.control}
            data={data.generalInfo}
          />
        </div>
        <div className="recipe-controls_batch-info">
          <h3>Batch Info</h3>
          <FormControlsReadOnly
            fields={fieldsProvider(t).recipeBatchInfoFields.control}
            data={data.batchInfo}
          />
        </div>
        <div className="recipe-controls_mash-info">
          <h3>Mash Info</h3>
          <FormControlsReadOnly
            fields={fieldsProvider(t).recipeMashInfoFields.control}
            data={data.mashInfo}
          />
        </div>
      </div>
      <div>
      {data?.fermentingIngredients && (
          <DynamicTable
            tableKey="fermentingIngredients"
            tableTitle="Fermenting Ingredients"
            dataCategory="brewery"
            data={data.fermentingIngredients}
            handleDoubleClick={() => {}}
          />
        )}
        {data?.hops &&(
            <DynamicTable
              tableKey="hops"
              tableTitle="Hops"
              dataCategory="brewery"
              data={data.hops}
              handleDoubleClick={() => {}}
            />
          )}
          {data?.yeast &&(
              <DynamicTable
                tableKey="yeast"
                tableTitle="Yeast"
                dataCategory="brewery"
                data={data.yeast}
                handleDoubleClick={() => {}}
              />
            )}
      </div>
    </div>
  );
};

export default RecipeDetails;
