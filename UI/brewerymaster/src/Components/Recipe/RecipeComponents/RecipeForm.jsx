import React, {useState} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';
import { toast } from "react-toastify";

import { useTranslation } from 'react-i18next';

import { addData } from '../api';

import MenuSteps from '../../Shared/MenuSteps';
import RecipeIngredients from "./RecipeIngredients";
import RecipeSummary from "./RecipeSummary";
import RecipeMash from "./RecipeMash";
import RecipeBatch from "./RecipeBatch";

const RecipeForm = () => {    
  const { t } = useTranslation();

  const [currentStep, setCurrentStep] = useState(0);
  const [recipeSummaryData, setRecipeSummaryData] = useState({
    name: "",
    blgScale: "",
    ibuScale: "",
    abvScale: "",
    srmScale: "",
    type: "",
  });

  const [recipeBatchData, setRecipeBatchData] = useState({
    batchSize: "",
    expectedBeerVolume: "",
    boilTime: "",
    evaporationRate: "",
    wortVolume: "",
    boilLoss: "",
    preBoilGravity: "",
    fermentationLoss: "",
    dryHopLoss: "",
  });

  const [recipeMashData, setRecipeMashData] = useState({
    mashEfficiency: "",
    waterToGrainRatio: "",
    mashWaterVolume: "",
    totalMashVolume: "",
  });

  const [boilSteps, setBoilSteps] = useState([]);
  
  const handleSave = () => {
    const newData = {
    };
  
    addData(newData)
      .then(() => {
        clear();
        toast.success(t("toast.addSuccess"));
      })
  };
  
  const clear = () => {
  };

  const steps = [
    {
      name: t("recipe.step.basicInformation"),
      component: (
        <RecipeSummary
          recipeSummaryData={recipeSummaryData}
          setRecipeSummaryData={setRecipeSummaryData}
        />
      ),
    },
    {
      name: t("recipe.step.fermentingIngredients"),
      component: <RecipeIngredients />,
    },
    {
      name: t("recipe.step.batch"),
      component: (
        <RecipeBatch
          recipeBatchData={recipeBatchData}
          setRecipeBatchData={setRecipeBatchData}
        />
      ),
    },
    {
      name: t("recipe.step.mash"),
      component: (
        <RecipeMash
          recipeMashData={recipeMashData}
          setRecipeMashData={setRecipeMashData}
        />
      ),
    },
  ];

  return (
    <Form className="recipe-form">
      <MenuSteps currentStep={currentStep} setCurrentStep={setCurrentStep} amountOfSteps={steps.length} />

      <h2>{steps[currentStep].name}</h2>
      <div>{steps[currentStep].component}</div>

      {currentStep === steps.length - 1 ? (
        <Button variant="dark" onClick={handleSave}>
          {t("button.submit")}
        </Button>
      ) : null}
    </Form>
  );
};

export default RecipeForm;