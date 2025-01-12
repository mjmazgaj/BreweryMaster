import { useState } from "react";
import { toast } from "react-toastify";
import { addData } from '../../api';

import { useTranslation } from 'react-i18next';
export const useRecipeForm = (isValid) => {
  const { t } = useTranslation();

  const [currentStep, setCurrentStep] = useState(0);
  const [selectedIngredients, setSelectedIngredients] = useState([]);
  const [selectedHops, setSelectedHops] = useState([]);
  const [selectedYeast, setSelectedYeast] = useState([]);
  const [selectedExtras, setSelectedExtras] = useState([]);

  const [recipeSummaryData, setRecipeSummaryData] = useState({
    name: "",
    blgScale: "",
    ibuScale: "",
    abvScale: "",
    srmScale: "",
    type: "",
  });

  const [recipeBatchData, setRecipeBatchData] = useState({
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
  

  const handleFormSubmit = (event) =>{
    if(recipeSummaryData.name || recipeSummaryData.name.length === 0)
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
      ingredients: selectedIngredients,
      hops: selectedHops,
      yeast: selectedYeast,
      extras: selectedExtras,
      ...recipeBatchData, 
      ...recipeMashData,
    };

    console.log("add");
    console.log({...newData});
    clear();
  };

  const clear = () => {
    setRecipeSummaryData({});
    setRecipeBatchData({});
    setRecipeMashData({});
    setBoilSteps([]);
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