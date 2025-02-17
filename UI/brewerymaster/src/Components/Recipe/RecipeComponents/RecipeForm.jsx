import React, {useState, useEffect} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';

import { useTranslation } from 'react-i18next';
import { useRecipeForm } from "./helpers/useRecipeForm";
import recipeFormFieldsProvider from "./helpers/recipeFormFieldsProvider";

import {fetchData} from "../../Shared/api"

import FormControls from "../../Shared/FormControls";
import MenuSteps from '../../Shared/MenuSteps';

import DynamicTableSelection from "../../Shared/TableComponents/DynamicTableSelection";

const RecipeForm = ({setIsAddMode}) => {    
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
  } = useRecipeForm({isValid, setIsAddMode});

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
      name: t("name.general.basicInformation"),
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
      name: t("name.brewery.fermentingIngredients"),
      component: (
        <DynamicTableSelection
          sourceTableTitle={t("name.brewery.ingredientsAvailable")}
          data={ingredients}
          dataCategory="brewery"
          selectedData={selectedIngredients}
          setSelectedData={setSelectedIngredients}
          quantityAction={{
            verb: "add",
            area: "ingredient"
          }}
        />
      ),
    },
    {
      key: "hops",
      name: t("name.brewery.hops"),
      component: (
        <DynamicTableSelection
          sourceTableTitle={t("name.brewery.hopsAvailable")}
          data={hops}
          dataCategory="brewery"
          selectedData={selectedHops}
          setSelectedData={setSelectedHops}
          quantityAction={{
            verb: "add",
            area: "ingredient"
          }}
        />
      ),
    },
    {
      key: "yeast",
      name: t("name.brewery.yeast"),
      component: (
        <DynamicTableSelection
          sourceTableTitle={t("name.brewery.yeastAvailable")}
          data={yeast}
          dataCategory="brewery"
          selectedData={selectedYeast}
          setSelectedData={setSelectedYeast}
          quantityAction={{
            verb: "add",
            area: "ingredient"
          }}
        />
      ),
    },
    {
      key: "extras",
      name: t("name.brewery.extras"),
      component: (
        <DynamicTableSelection
          sourceTableTitle={t("name.brewery.extrasAvailable")}
          data={extras}
          dataCategory="brewery"
          selectedData={selectedExtras}
          setSelectedData={setSelectedExtras}
          quantityAction={{
            verb: "add",
            area: "ingredient"
          }}
        />
      ),
    },
    {
      key: "batch",
      name: t("name.brewery.batch"),
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
      name: t("name.brewery.mash"),
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
    fetchData("FermentingIngredient/Unit", setIngredients);
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