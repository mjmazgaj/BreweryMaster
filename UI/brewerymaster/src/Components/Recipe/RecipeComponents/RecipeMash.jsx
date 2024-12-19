import React from "react";

import { useTranslation } from 'react-i18next';

import FormControl from "../../Shared/FormControls";
import RecipeFormFieldsProvider from "./RecipeFormProvider";

const RecipeMash = ({ recipeMashData, setRecipeMashData }) => {
  const { t } = useTranslation();

  return (
    <div className="recipe-mash_container">
      <FormControl
        fields={RecipeFormFieldsProvider(t).mashFields}
        data={recipeMashData}
        setData={setRecipeMashData}
      />
    </div>
  );
};

export default RecipeMash;