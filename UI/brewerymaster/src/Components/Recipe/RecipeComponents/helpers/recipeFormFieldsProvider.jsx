const recipeFormFieldsProvider = (t) => ({
  summaryFields: [
    {
      id: "name",
      label: `${t("common.name")}*`,
      type: "text",
      required: true,
      feedback: `${t("common.validation.text")}`
    },
    {
      id: "blgScale",
      label: t("recipe.blgScale"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "ibuScale",
      label: t("recipe.ibuScale"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-1000`,
      validation:{
        min: 0,
        max: 1000,
      }
    },
    {
      id: "abvScale",
      label: t("recipe.abvScale"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "srmScale",
      label: t("recipe.srmScale"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "type",
      label: t("common.type"),
      type: "text",
    },
    {
      id: "style",
      label: t("common.style"),
      type: "text",
    },
  ],
  batchFields: [
    {
      id: "expectedBeerVolume",
      label: t("recipe.batch.expectedBeerVolume"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-10000`,
      validation:{
        min: 0,
        max: 10000,
      }
    },
    {
      id: "boilingTime",
      label: t("recipe.batch.boilingTime"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-10000`,
      validation:{
        min: 0,
        max: 10000,
      }
    },
    {
      id: "evaporationRate",
      label: t("recipe.batch.evaporationRate"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "boiledWortVolume",
      label: t("recipe.batch.boiledWortVolume"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-10000`,
      validation:{
        min: 0,
        max: 10000,
      }
    },
    {
      id: "boilingLosses",
      label: t("recipe.batch.boilingLosses"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "preBoilingDensity",
      label: t("recipe.batch.preBoilingDensity"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "fermentationLosses",
      label: t("recipe.batch.fermentationLosses"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
    {
      id: "dryHoppingLosses",
      label: t("recipe.batch.dryHoppingLosses"),
      type: "number",
      feedback: `${t("common.validation.number")} 0-100`,
      validation:{
        min: 0,
        max: 100,
      }
    },
  ],
  mashFields: [
    {
      id: "mashEfficiency",
      label: t("recipe.mash.efficiency"),
      type: "number",
    },
    {
      id: "waterToGrainRatio",
      label: t("recipe.mash.waterToGrainRatio"),
      type: "number",
    },
    {
      id: "mashWaterVolume",
      label: t("recipe.mash.mashWaterVolume"),
      type: "number",
    },
    {
      id: "totalMashVolume",
      label: t("recipe.mash.totalMashVolume"),
      type: "number",
    },
  ],
});

export default recipeFormFieldsProvider;