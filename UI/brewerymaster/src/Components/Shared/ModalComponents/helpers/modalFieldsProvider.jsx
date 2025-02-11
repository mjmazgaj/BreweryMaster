const modalFieldsProvider = (t) => ({
  fermentingIngredientsModalFields: [
    {
      id: "name",
      label: t("name.brewery.name"),
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      }
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
      }
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
      }
    },
    {
      id: "ebc",
      label: t("name.brewery.ebc"),
      type: "number",
      feedback: `${t("validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      }
    },
  ],
  fermentingIngredientsModalReadOnlyFields: [
    {
      id: "typeName",
      label: t("name.brewery.type"),
      type: "text",
    },
    {
      id: "name",
      label: t("name.brewery.name"),
      type: "text",
    },
    {
      id: "storedQuantity",
      label: t("name.brewery.storedQuantity"),
      type: "number",
    },
    {
      id: "percentage",
      label: t("name.brewery.percentage"),
      type: "number",
    },
    {
      id: "extraction",
      label: t("name.brewery.extraction"),
      type: "number",
    },
    {
      id: "ebc",
      label: t("name.brewery.ebc"),
      type: "number",
    },
  ],
  quantityModalFields:{
    reserve:[
      {
        id: "reserveQuantity",
        label: t("name.brewery.reserveQuantity"),
        type: "number",
      },
      {
        id: "description",
        label: t("name.brewery.description"),
        type: "textArea",
      },
    ],
    order:[
      {
        id: "orderQuantity",
        label: t("name.brewery.orderQuantity"),
        type: "number",
      },
      {
        id: "description",
        label: t("name.brewery.description"),
        type: "textArea",
      },
    ],
    ingredient:[
      {
        id: "quantity",
        label: t("name.brewery.quantity"),
        type: "number",
      },
      {
        id: "description",
        label: t("name.brewery.description"),
        type: "textArea",
      },
    ]
  },
});

export default modalFieldsProvider;