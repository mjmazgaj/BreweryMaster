import { useState } from "react";
import { toast } from "react-toastify";
import { addData } from '../../api';

import { useTranslation } from 'react-i18next';
export const useRecipeForm = (isValid) => {
  const { t } = useTranslation();

  const [currentStep, setCurrentStep] = useState(0);
  const [selectedIngredients, setSelectedIngredients] = useState({});
  const [selectedHops, setSelectedHops] = useState({});
  const [selectedYeast, setSelectedYeast] = useState({});
  const [selectedExtras, setSelectedExtras] = useState({});

  const [recipeSummaryData, setRecipeSummaryData] = useState({
    name: "",
    blgScale: null,
    ibuScale: null,
    abvScale: null,
    srmScale: null,
    type: null,
  });

  const [recipeBatchData, setRecipeBatchData] = useState({
    expectedBeerVolume: null,
    boilTime: null,
    evaporationRate: null,
    wortVolume: null,
    boilLoss: null,
    preBoilGravity: null,
    fermentationLoss: null,
    dryHopLoss: null,
  });

  const [recipeMashData, setRecipeMashData] = useState({
    mashEfficiency: null,
    waterToGrainRatio: null,
    mashWaterVolume: null,
    totalMashVolume: null,
  });

  const [boilSteps, setBoilSteps] = useState([]);
  

  const handleFormSubmit = (event) =>{
    if(!(recipeSummaryData || recipeSummaryData.name || recipeSummaryData.name.length === 0))
    {
      toast.error("Name is missing");
    }
    console.log(isValid)
    const form = event.currentTarget;
    event.preventDefault();

    if (form.checkValidity() === false || !isValid) {
      event.stopPropagation();
      return false;
    }

    return true;
  }

  const handleSave = (event) => {
    if (!handleFormSubmit(event)) {
      return;
    }
    const newData = 
    {
      ...recipeSummaryData,
      fermentingIngredients: selectedIngredients,
      hops: selectedHops,
      yeast: selectedYeast,
      extras: selectedExtras,
      ...recipeBatchData, 
      ...recipeMashData,
    };

    console.log("add");
    console.log({...newData});
    addData("recipe", newData);
    clear();
  };

  const clear = () => {
    setRecipeSummaryData({});
    setRecipeBatchData({});
    setRecipeMashData({});
    setBoilSteps([]);
    setSelectedIngredients({});
    setSelectedHops({});
    setSelectedExtras({});
    setSelectedYeast({});
  };

  return {
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
    boilSteps,
    setBoilSteps,
    handleSave,
    clear,
  };
};