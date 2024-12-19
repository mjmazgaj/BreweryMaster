import React from "react";

import { useTranslation } from 'react-i18next';

import FormControls from "../../Shared/FormControls";
import RecipeFormFieldsProvider from "./RecipeFormProvider";

const RecipeSummary = ({
  recipeSummaryData,
  setRecipeSummaryData,
}) => {
  const { t } = useTranslation();
  
  const fields = [
    {
      id: "name",
      label: t("common.name"),
      type: "text",
    },
    {
      id: "blgScale",
      label: t("recipe.blgScale"),
      type: "number",
      min: 0,
      max: 100
    },
    {
      id: "ibuScale",
      label: t("recipe.ibuScale"),
      type: "number",
      min: 0,
      max: 1000
    },
    {
      id: "abvScale",
      label: t("recipe.abvScale"),
      type: "number",
      min: 0,
      max: 100
    },
    {
      id: "srmScale",
      label: t("recipe.srmScale"),
      type: "number",
      min: 0,
      max: 100
    },
    {
      id: "type",
      label: t("common.type"),
      type: "text",
    },
    {
      id: "style",
      label: t("common.style"),
      type: "text",
    },
  ];

  return (
    <div className="recipe-summary_container">
    <FormControls
      fields={fields}
      data={recipeSummaryData}
      setData={setRecipeSummaryData}
    />
    </div>
  );
};

export default RecipeSummary;