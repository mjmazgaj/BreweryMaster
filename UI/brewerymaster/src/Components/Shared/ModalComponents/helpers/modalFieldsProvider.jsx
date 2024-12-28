const modalFieldsProvider = (t) => ({
  fermentingIngredientsModalFields: [
    {
      id: "type",
      label: t("recipe.ingredients.type"),
      type: "text",
    },
    {
      id: "name",
      label: t("recipe.ingredients.name"),
      type: "text",
    },
    {
      id: "quantity",
      label: t("recipe.ingredients.quantity"),
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
});

export default modalFieldsProvider;