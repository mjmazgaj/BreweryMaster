const modalFieldsProvider = (t) => ({
  prospectOrderModalModalFields: [
    {
      id: "clientName",
      label: t("name.name"),
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "email",
      label: t("name.email"),
      type: "text",
      required: true,
      feedback: `${t("validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      },
    },
    {
      id: "phoneNumber",
      label: t("name.phoneNumber"),
      type: "text",
      required: true,
      feedback: `${t("validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      },
    },
    {
      id: "capacity",
      label: t("name.brewery.capacity"),
      type: "number",
      required: true,
      feedback: `${t("validation.number")} 0-100`,
      validation: {
        min: 0,
        max: 100,
      },
    },
  ],
  prospectOrderModalReadOnlyFields: [
    {
      id: "clientName",
      label: t("name.clientName"),
      type: "text",
    },
    {
      id: "email",
      label: t("name.email"),
      type: "text",
    },
    {
      id: "phoneNumber",
      label: t("name.phoneNumber"),
      type: "text",
    },
    {
      id: "beerStyle",
      label: t("name.brewery.beerStyle"),
      type: "text",
    },
    {
      id: "container",
      label: t("name.brewery.container"),
      type: "text",
    },
    {
      id: "capacity",
      label: t("name.brewery.capacity"),
      type: "number",
    },
    {
      id: "isClosedString",
      label: t("name.brewery.isClosed"),
      type: "text",
    },
  ],
});

export default modalFieldsProvider;
