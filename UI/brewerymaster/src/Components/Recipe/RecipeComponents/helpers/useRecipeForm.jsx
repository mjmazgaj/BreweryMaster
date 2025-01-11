import { useState } from "react";
import { toast } from "react-toastify";
import { addData } from '../../api';

import { useTranslation } from 'react-i18next';
export const useRecipeForm = () => {
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
  
  const handleSave = () => {
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

    addData(newData).then(() => {
      clear();
      toast.success(t("toast.addSuccess"));
    });
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