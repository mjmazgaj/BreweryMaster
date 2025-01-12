import React, {useState, useEffect} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';

import { useTranslation } from 'react-i18next';
import { useRecipeForm } from "./helpers/useRecipeForm";
import recipeFormFieldsProvider from "./helpers/recipeFormFieldsProvider";

import {fetchData} from "../api"

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
    selectedExtras,
    setSelectedExtras,
    recipeSummaryData,
    setRecipeSummaryData,
    recipeBatchData,
    setRecipeBatchData,
    recipeMashData,
    setRecipeMashData,
    handleSave,
    clear
  } = useRecipeForm(isValid);

  const [ingredients, setIngredients] = useState([]);
  
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

  const [extras, setExtras] = useState([
    {
      id: 1,
      type: "Klarowanie",
      name: "Wirflock",
      quantity: 2,
      usedFor: "Gotowanie",
      time: "5 min",
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
      key: "extras",
      name: t("recipe.step.extras"),
      component: (
        <DynamicTableSelection
          sourceTableTitle={t("recipe.extrasAvailable")}
          data={extras}
          setData={setExtras}
          targetTableTitle={t("recipe.extrasSelected")}
          selectedData={selectedExtras}
          setSelectedData={setSelectedExtras}
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
  
  
  useEffect(() => {
    fetchData("FermentingIngredient/Summary", setIngredients);
  }, []);

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
        <Button type="submit" variant="dark" onClick={handleSave}>
          {t("button.submit")}
        </Button>
      ) : null}
    </Form>
  );
};

export default RecipeForm;