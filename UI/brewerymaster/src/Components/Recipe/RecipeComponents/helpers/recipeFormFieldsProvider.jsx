const recipeFormFieldsProvider = (t) => ({
  summaryFields: [
    {
      id: "name",
      label: `${t("name.general.name")}*`,
      type: "text",
      required: true,
      feedback: `${t("validation.text")}`
    },
    {
      id: "blgScale",
      label: t("name.brewery.blgScale"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "ibuScale",
      label: t("name.brewery.ibuScale"),
      type: "number",
      feedback: `${t("validation.number")} 0-1000`,
      validation:{
        min: 0,
        max: 1000,
      }
    },
    {
      id: "abvScale",
      label: t("name.brewery.abvScale"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "srmScale",
      label: t("name.brewery.srmScale"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "type",
      label: t("name.brewery.type"),
      type: "text",
    },
    {
      id: "style",
      label: t("name.brewery.style"),
      type: "text",
    },
  ],
  batchFields: [
    {
      id: "expectedBeerVolume",
      label: `${t("name.brewery.expectedBeerVolume")}*`,
      type: "number",
      required: true,
      feedback: `${t("validation.number")} 0-10000`,
      validation:{
        min: 0,
        max: 10000,
      }
    },
    {
      id: "boilingTime",
      label: t("name.brewery.boilingTime"),
      type: "number",
      feedback: `${t("validation.number")} 0-10000`,
      validation:{
        min: 0,
        max: 10000,
      }
    },
    {
      id: "evaporationRate",
      label: t("name.brewery.evaporationRate"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "wortVolume",
      label: `${t("name.brewery.boiledWortVolume")}*`,
      type: "number",
      required: true,
      feedback: `${t("validation.number")} 0-10000`,
      validation:{
        min: 0,
        max: 10000,
      }
    },
    {
      id: "boilingLosses",
      label: t("name.brewery.boilingLosses"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "preBoilingDensity",
      label: t("name.brewery.preBoilingDensity"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "fermentationLosses",
      label: t("name.brewery.fermentationLosses"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "dryHoppingLosses",
      label: t("name.brewery.dryHoppingLosses"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
  ],
  mashFields: [
    {
      id: "mashEfficiency",
      label: t("name.brewery.efficiency"),
      type: "number",
    },
    {
      id: "waterToGrainRatio",
      label: t("name.brewery.waterToGrainRatio"),
      type: "number",
    },
    {
      id: "mashWaterVolume",
      label: t("name.brewery.mashWaterVolume"),
      type: "number",
    },
    {
      id: "totalMashVolume",
      label: t("name.brewery.totalMashVolume"),
      type: "number",
    },
  ],
});

export default recipeFormFieldsProvider;