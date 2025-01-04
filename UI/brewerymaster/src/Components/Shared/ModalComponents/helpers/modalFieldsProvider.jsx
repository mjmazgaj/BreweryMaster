const modalFieldsProvider = (t) => ({
  fermentingIngredientsModalFields: [
    {
      id: "name",
      label: t("recipe.ingredients.name"),
      type: "text",
    },
    {
      id: "storedQuantity",
      label: t("recipe.ingredients.storedQuantity"),
      type: "number",
    },
    {
      id: "percentage",
      label: t("recipe.ingredients.percentage"),
      type: "number",
    },
    {
      id: "extraction",
      label: t("recipe.ingredients.extraction"),
      type: "number",
    },
    {
      id: "ebc",
      label: t("recipe.ingredients.ebc"),
      type: "number",
    },
  ],
  quantityModalFields:{
    reserve:[
      {
        id: "reserveQuantity",
        label: t("recipe.ingredients.reserveQuantity"),
        type: "number",
      },
      {
        id: "describtion",
        label: t("recipe.ingredients.describtion"),
        type: "textArea",
      },
    ],
    order:[
      {
        id: "orderQuantity",
        label: t("recipe.ingredients.orderQuantity"),
        type: "number",
      },
      {
        id: "describtion",
        label: t("recipe.ingredients.describtion"),
        type: "textArea",
      },
    ]
  },
});

export default modalFieldsProvider;