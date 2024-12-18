import React, {Fragment, useState} from "react";

import { Form } from "react-bootstrap";
import { useTranslation } from 'react-i18next';
import FormControl from "../../Shared/FormControl";

const RecipeBatch = ({ recipeBatchData, setRecipeBatchData }) => {
  const { t } = useTranslation();
  
    const fields = [
      {
        id: "expectedBeerVolume",
        label: t("recipe.batch.expectedBeerVolume"),
        type: "number",
        min: 0,
        max: 100000
      },
      {
        id: "boilingTime",
        label: t("recipe.batch.boilingTime"),
        type: "number",
        min: 0,
        max: 10000
      },
      {
        id: "evaporationRate",
        label: t("recipe.batch.evaporationRate"),
        type: "number",
        min: 0,
        max: 100
      },
      {
        id: "boiledWortVolume",
        label: t("recipe.batch.boiledWortVolume"),
        type: "number",
        min: 0,
        max: 10000
      },
      {
        id: "boilingLosses",
        label: t("recipe.batch.boilingLosses"),
        type: "number",
        min: 0,
        max: 100
      },
      {
        id: "preBoilingDensity",
        label: t("recipe.batch.preBoilingDensity"),
        type: "number",
        min: 0,
        max: 100
      },
      {
        id: "fermentationLosses",
        label: t("recipe.batch.fermentationLosses"),
        type: "number",
        min: 0,
        max: 100
      },
      {
        id: "dryHoppingLosses",
        label: t("recipe.batch.dryHoppingLosses"),
        type: "number",
        min: 0,
        max: 100
      }
    ];

  return (
    <div className="recipe-mash_container">
      <FormControl
        fields={fields}
        data={recipeBatchData}
        setData={setRecipeBatchData}
      />
    </div>
  );
};

export default RecipeBatch;