const modalFieldsProvider = (t) => ({
  prospectOrderModalModalFields: [
    {
      id: "clientName",
      label: t("prospectOrder.name"),
      type: "text",
      required: true,
      feedback: `${t("common.validation.text")} 255`,
      validation: {
        maxLength: 255,
      }
    },
    {
      id: "email",
      label: t("prospectOrder.email"),
      type: "text",
      required: true,
      feedback: `${t("common.validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      }
    },
    {
      id: "phoneNumber",
      label: t("prospectOrder.phoneNumber"),
      type: "text",
      required: true,
      feedback: `${t("common.validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      }
    },
    {
      id: "capacity",
      label: t("prospectOrder.capacity"),
      type: "number",
      required: true,
      feedback: `${t("common.validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      }
    },
  ],
  prospectOrderModalReadOnlyFields: [
    {
      id: "clientName",
      label: t("column.clientName"),
      type: "text",
    },
    {
      id: "email",
      label: t("column.email"),
      type: "text",
    },
    {
      id: "phoneNumber",
      label: t("column.phoneNumber"),
      type: "text",
    },
    {
      id: "beerStyle",
      label: t("column.beerStyle"),
      type: "text",
    },
    {
      id: "container",
      label: t("column.container"),
      type: "text",
    },
    {
      id: "capacity",
      label: t("column.capacity"),
      type: "number",
    },
    {
      id: "isClosedString",
      label: t("column.isClosed"),
      type: "text",
    },
  ],
});

export default modalFieldsProvider;