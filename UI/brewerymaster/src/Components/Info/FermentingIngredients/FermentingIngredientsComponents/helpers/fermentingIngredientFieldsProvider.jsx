const fermentingIngredientFieldsProvider = (t) => ({
  infoFields: {
    control: [
      { id: "typeName", label: t("name.brewery.typeName"), type: "textArea" },
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
  modalFields: [
    {
      id: "name",
      label: t("name.brewery.name"),
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "percentage",
      label: t("name.brewery.percentage"),
      type: "number",
      required: true,
      feedback: `${t("validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      },
    },
    {
      id: "extraction",
      label: t("name.brewery.extraction"),
      type: "number",
      required: true,
      feedback: `${t("validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      },
    },
    {
      id: "ebc",
      label: t("name.brewery.ebc"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      },
    },
    {
      id: "info",
      label: t("name.brewery.info"),
      type: "text",
    },
  ],
});

export default fermentingIngredientFieldsProvider;
