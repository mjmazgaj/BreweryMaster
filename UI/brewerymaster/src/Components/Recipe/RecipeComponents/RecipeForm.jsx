import React from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';

import { useTranslation } from 'react-i18next';
import { useRecipeForm } from "./helpers/useRecipeForm";
import recipeFormFieldsProvider from "./helpers/recipeFormFieldsProvider";

import FormControls from "../../Shared/FormControls";
import MenuSteps from '../../Shared/MenuSteps';

import RecipeIngredients from "./RecipeIngredients";

const RecipeForm = () => {    
  const { t } = useTranslation();

  const {
    currentStep,
    setCurrentStep,
    recipeSummaryData,
    setRecipeSummaryData,
    recipeBatchData,
    setRecipeBatchData,
    recipeMashData,
    setRecipeMashData,
    handleSave,
    clear,
  } = useRecipeForm();

  const steps = [
    {
      key: "basicInformation",
      name: t("recipe.step.basicInformation"),
      component: (
        <FormControls
          fields={recipeFormFieldsProvider(t).summaryFields}
          data={recipeSummaryData}
          setData={setRecipeSummaryData}
        />
      ),
    },
    {
      key: "fermentingIngredients",
      name: t("recipe.step.fermentingIngredients"),
      component: <RecipeIngredients />,
    },
    {
      key: "batch",
      name: t("recipe.step.batch"),
      component: (
        <FormControls
          fields={recipeFormFieldsProvider(t).batchFields}
          data={recipeBatchData}
          setData={setRecipeBatchData}
        />
      ),
    },
    {
      key: "mash",
      name: t("recipe.step.mash"),
      component: (
        <FormControls
          fields={recipeFormFieldsProvider(t).mashFields}
          data={recipeMashData}
          setData={setRecipeMashData}
        />
      ),
    },
  ];

  return (
    <Form className="recipe-form">
      <MenuSteps
        currentStep={currentStep}
        setCurrentStep={setCurrentStep}
        amountOfSteps={steps.length}
      />

      <h2>{steps[currentStep].name}</h2>
      <div className={`"recipe-${steps[currentStep].key}_container"`}>
        {steps[currentStep].component}
      </div>

      {currentStep === steps.length - 1 ? (
        <Button variant="dark" onClick={handleSave}>
          {t("button.submit")}
        </Button>
      ) : null}
    </Form>
  );
};

export default RecipeForm;