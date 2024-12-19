import React from "react";

import { useTranslation } from 'react-i18next';

import FormControls from "../../Shared/FormControls";
import RecipeFormFieldsProvider from "./RecipeFormProvider";

const RecipeBatch = ({ recipeBatchData, setRecipeBatchData }) => {
  const { t } = useTranslation();

  return (
    <div className="recipe-batch_container">
      <FormControls
        fields={RecipeFormFieldsProvider(t).batchFields}
        data={recipeBatchData}
        setData={setRecipeBatchData}
      />
    </div>
  );
};

export default RecipeBatch;