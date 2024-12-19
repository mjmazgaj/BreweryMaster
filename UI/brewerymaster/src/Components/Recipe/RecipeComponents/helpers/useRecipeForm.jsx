import { useState } from "react";

export const useRecipeForm = () => {
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
    clear,
  };
};