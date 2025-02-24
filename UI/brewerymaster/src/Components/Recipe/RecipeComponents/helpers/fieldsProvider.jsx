const fieldsProvider = (t) => ({
  recipeGeneralInfoFields: {
    control: [
      {
        id: "name",
        label: t("name.brewery.name"),
        type: "textArea",
      },
      {
        id: "blgScale",
        label: t("name.brewery.blgScale"),
        type: "textArea",
      },
      {
        id: "ibuScale",
        label: t("name.brewery.ibuScale"),
        type: "textArea",
      },
      {
        id: "abvScale",
        label: t("name.brewery.abvScale"),
        type: "textArea",
      },
      {
        id: "srmScale",
        label: t("name.brewery.srmScale"),
        type: "textArea",
      },
      {
        id: "typeName",
        label: t("name.brewery.typeName"),
        type: "textArea",
      },
      {
        id: "styleName",
        label: t("name.brewery.styleName"),
        type: "textArea",
      },
    ],
  },
  recipeBatchInfoFields: {
    control: [
      {
        id: "expectedBeerVolume",
        label: t("name.brewery.expectedBeerVolume"),
        type: "textArea",
      },
      {
        id: "boilTime",
        label: t("name.brewery.boilTime"),
        type: "textArea",
      },
      {
        id: "evaporationRate",
        label: t("name.brewery.evaporationRate"),
        type: "textArea",
      },
      {
        id: "wortVolume",
        label: t("name.brewery.boiledWortVolume"),
        type: "textArea",
      },
      {
        id: "boilLoss",
        label: t("name.brewery.boilingLosses"),
        type: "textArea",
      },
      {
        id: "preBoilGravity",
        label: t("name.brewery.preBoilingDensity"),
        type: "textArea",
      },
      {
        id: "fermentationLoss",
        label: t("name.brewery.fermentationLosses"),
        type: "textArea",
      },
      {
        id: "dryHopLoss",
        label: t("name.brewery.dryHoppingLosses"),
        type: "textArea",
      },
    ],
  },
  recipeMashInfoFields: {
    control: [
      {
        id: "mashEfficiency",
        label: t("name.brewery.efficiency"),
        type: "textArea",
      },
      {
        id: "waterToGrainRatio",
        label: t("name.brewery.waterToGrainRatio"),
        type: "textArea",
      },
      {
        id: "mashWaterVolume",
        label: t("name.brewery.mashWaterVolume"),
        type: "textArea",
      },
      {
        id: "totalMashVolume",
        label: t("name.brewery.totalMashVolume"),
        type: "textArea",
      },
    ],
  },
  filterFields:{
    control: [
      {
        id: "name",
        label: t("name.general.name"),
        type: "textArea",
      },
    ],
  }
});

export default fieldsProvider;
