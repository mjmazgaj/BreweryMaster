import React, {Fragment, useState} from "react";

import { Form } from "react-bootstrap";
import { useTranslation } from 'react-i18next';
import FormControl from "../../Shared/FormControl";

const RecipeMash = ({ recipeMashData, setRecipeMashData }) => {
  const { t } = useTranslation();
  
    const fields = [
      {
        id: "mashEfficiency",
        label: t("recipe.mash.efficiency"),
        type: "number",
      },
      {
        id: "waterToGrainRatio",
        label: t("recipe.mash.waterToGrainRatio"),
        type: "number",
      },
      {
        id: "mashWaterVolume",
        label: t("recipe.mash.mashWaterVolume"),
        type: "number",
      },
      {
        id: "totalMashVolume",
        label: t("recipe.mash.totalMashVolume"),
        type: "number",
      },
    ];

  return (
    <div className="recipe-mash_container">
      <FormControl
        fields={fields}
        data={recipeMashData}
        setData={setRecipeMashData}
      />
    </div>
  );
};

export default RecipeMash;