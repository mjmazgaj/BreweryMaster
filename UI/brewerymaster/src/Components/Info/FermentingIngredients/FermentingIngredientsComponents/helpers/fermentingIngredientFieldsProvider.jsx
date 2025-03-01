const fermentingIngredientFieldsProvider = (t) => ({
  infoFields: {
    control: [
      { id: "typeName", label: t("name.brewery.typeName"), type: "textArea" },
      { id: "name", label: t("name.brewery.name"), type: "textArea" },
      {
        id: "percentage",
        label: t("name.brewery.percentage"),
        type: "textArea",
      },
      {
        id: "extraction",
        label: t("name.brewery.extraction"),
        type: "textArea",
      },
      { id: "ebc", label: t("name.brewery.ebc"), type: "textArea" },
      {
        id: "totalQuantity",
        label: t("name.brewery.totalQuantity"),
        type: "textArea",
      },
      { id: "unit", label: t("name.brewery.unit"), type: "textArea" },
      { id: "info", label: t("name.brewery.info"), type: "textArea" },
    ],
  },
  quantityFields: [
    {
      id: "storedQuantity",
      label: t("name.brewery.storedQuantity"),
      type: "textArea",
    },
    {
      id: "reservedQuantity",
      label: t("name.brewery.reservedQuantity"),
      type: "textArea",
    },
    {
      id: "orderedQuantity",
      label: t("name.brewery.orderedQuantity"),
      type: "textArea",
    },
  ],
});

export default fermentingIngredientFieldsProvider;
