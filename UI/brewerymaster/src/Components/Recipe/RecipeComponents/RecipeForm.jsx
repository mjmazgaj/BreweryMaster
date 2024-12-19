import React, {useState} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';

import { useTranslation } from 'react-i18next';
import { useRecipeForm } from "./helpers/useRecipeForm";
import recipeFormFieldsProvider from "./helpers/recipeFormFieldsProvider";

import FormControls from "../../Shared/FormControls";
import MenuSteps from '../../Shared/MenuSteps';

import DynamicTableSelection from "../../Shared/DynamicTableSelection";

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

const [ingredients, setIngredients] = useState([
    { id: 1, name: 'Flour', quantity: 1000 },
    { id: 2, name: 'Sugar', quantity: 500 },
    { id: 3, name: 'Butter', quantity: 250 },
  ]);

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
      component: (
        <DynamicTableSelection
          key="ingredients"
          sourceTableKey="ingredientsAvailable"
          sourceTableTitle={t("recipe.ingredientsAvailable")}
          data={ingredients}
          setData={setIngredients}
          targetTableKey="ingredientsAvailable"
          targetTableTitle={t("recipe.ingredientsAvailable")}
        />
      ),
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