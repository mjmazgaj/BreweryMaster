import React, {useState} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';
import { toast } from "react-toastify";

import { useTranslation } from 'react-i18next';

import { addData } from '../api';

import MenuSteps from '../../Shared/MenuSteps';
import RecipeIngredients from "./RecipeIngredients";
import RecipeSummary from "./RecipeSummary";

const RecipeForm = () => {    
  const { t } = useTranslation();

  const [currentStep, setCurrentStep] = useState(0);
  const [recipeSummaryData, setRecipeSummaryData] = useState({
    blgScale: "",
    ibuScale: "",
    abvScale: "",
    srmScale: "",
    type: "",
  });

  const [batchData, setBatchData] = useState({
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

  const [mashData, setMashData] = useState({
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
      name: t("common.ingredients"),
      component: <RecipeIngredients />,
    },
    {
      name: t("common.summary"),
      component: <RecipeSummary recipeSummaryData={recipeSummaryData} setRecipeSummaryData={setRecipeSummaryData}/>,
    },
  ];

  return (
    <Form className="recipe-form">
      <MenuSteps currentStep={currentStep} setCurrentStep={setCurrentStep} amountOfSteps={steps.length} />

      <h2>{steps[currentStep].name}</h2>
      <div>{steps[currentStep].component}</div>

      {currentStep === steps.length - 1 ? (
        <Button variant="dark" onClick={handleSave}>
          {t("common.submit")}
        </Button>
      ) : null}
    </Form>
  );
};

export default RecipeForm;