import { useState } from "react";
import { toast } from "react-toastify";
import { addData } from '../../api';

import { useTranslation } from 'react-i18next';
export const useRecipeForm = () => {
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
    const newData = 
    {
      ...recipeSummaryData,
      ...recipeMashData, 
      ...recipeBatchData
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