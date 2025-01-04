import React, {useState} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';

import { useTranslation } from 'react-i18next';
import { useRecipeForm } from "./helpers/useRecipeForm";
import recipeFormFieldsProvider from "./helpers/recipeFormFieldsProvider";

import FormControls from "../../Shared/FormControls";
import MenuSteps from '../../Shared/MenuSteps';

import DynamicTableSelection from "../../Shared/TableComponents/DynamicTableSelection";

const RecipeForm = () => {    
  const { t } = useTranslation();
  const [isValid, setIsValid] = useState(true);

  const {
    currentStep,
    setCurrentStep,
    selectedIngredients,
    setSelectedIngredients,
    selectedHops,
    setSelectedHops,
    selectedYeast,
    setSelectedYeast,
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
    { 
      id: 1, 
      type: 'Grain', 
      name: 'Viking Pilsner malt', 
      quantity: 3, 
      percentage: 62.5, 
      extraction: 82, 
      ebc: 4 
    },
    { 
      id: 2, 
      type: 'Grain', 
      name: 'Strzegom Monachijski typ II', 
      quantity: 1, 
      percentage: 20.8, 
      extraction: 79, 
      ebc: 22 
    },
    { 
      id: 3, 
      type: 'Grain', 
      name: 'Strzegom Karmel 150', 
      quantity: 0.5, 
      percentage: 10.4, 
      extraction: 75, 
      ebc: 150 
    },
    { 
      id: 4, 
      type: 'Grain', 
      name: 'Oats, Flaked', 
      quantity: 0.3, 
      percentage: 6.3, 
      extraction: 80, 
      ebc: 2 
    }
  ]);
  
  const [hops, setHops] = useState([
    { 
      id: 1, 
      usage: 'Gotowanie', 
      name: 'Citra', 
      quantity: 25,
      time: 60, 
      alphaAcids: 12.0
    },
    { 
      id: 2, 
      usage: 'Gotowanie', 
      name: 'Citra', 
      quantity: 25, 
      time: 15, 
      alphaAcids: 12.0 
    },
    { 
      id: 3, 
      usage: 'Gotowanie', 
      name: 'Citra', 
      quantity: 25, 
      time: 10, 
      alphaAcids: 12.0 
    },
    { 
      id: 4, 
      usage: 'Aromat (koniec gotowania)', 
      name: 'Citra', 
      quantity: 25, 
      time: 5, 
      alphaAcids: 12.0 
    },
    { 
      id: 5, 
      usage: 'Na zimno', 
      name: 'Citra', 
      quantity: 50, 
      time: 7, 
      alphaAcids: 12.0 
    },
  ]);

  const [yeast, setYeast] = useState([
    {
      id: 1,
      name: "US05",
      type: "Ale",
      form: "Suche",
      quantity: 11,
      laboratory: "Gozdawa",
    },
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
          setIsValid={setIsValid}
        />
      ),
    },
    {
      key: "fermentingIngredients",
      name: t("recipe.step.fermentingIngredients"),
      component: (
        <DynamicTableSelection
          sourceTableTitle={t("recipe.ingredientsAvailable")}
          data={ingredients}
          setData={setIngredients}
          targetTableTitle={t("recipe.ingredientsSelected")}
          selectedData={selectedIngredients}
          setSelectedData={setSelectedIngredients}
        />
      ),
    },
    {
      key: "hops",
      name: t("recipe.step.hops"),
      component: (
        <DynamicTableSelection
          sourceTableTitle={t("recipe.hopsAvailable")}
          data={hops}
          setData={setHops}
          targetTableTitle={t("recipe.hopsSelected")}
          selectedData={selectedHops}
          setSelectedData={setSelectedHops}
        />
      ),
    },
    {
      key: "yeast",
      name: t("recipe.step.yeast"),
      component: (
        <DynamicTableSelection
          sourceTableTitle={t("recipe.yeastAvailable")}
          data={yeast}
          setData={setYeast}
          targetTableTitle={t("recipe.yeastSelected")}
          selectedData={selectedYeast}
          setSelectedData={setSelectedYeast}
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
          setIsValid={setIsValid}
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
          setIsValid={setIsValid}
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
        isValid={isValid}
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