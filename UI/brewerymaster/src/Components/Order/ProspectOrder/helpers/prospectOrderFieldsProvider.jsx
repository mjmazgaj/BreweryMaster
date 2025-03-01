const prospectOrderFieldsProvider = (t) => ({
  modalModalFields: [
    {
      id: "clientName",
      label: t("name.user.name"),
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "email",
      label: t("name.user.email"),
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
      label: t("name.user.phoneNumber"),
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
  modalReadOnlyFields: [
    {
      id: "clientName",
      label: t("name.user.clientName"),
      type: "text",
    },
    {
      id: "email",
      label: t("name.user.email"),
      type: "text",
    },
    {
      id: "phoneNumber",
      label: t("name.user.phoneNumber"),
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
  companyClientDetails: [
    {
      id: "companyName",
      label: t("name.user.companyName"),
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "nip",
      label: t("name.user.nip"),
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 12`,
      validation: {
        maxLength: 12,
      },
    },
  ],
  individualClientDetails: [
    {
      id: "forename",
      label: t("name.user.forename"),
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "surname",
      label: t("name.user.surname"),
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
  ],
  prospectOrderDetails: {
    control: [
      {
        id: "phoneNumber",
        label: t("name.user.phoneNumber"),
        type: "text",
        required: true,
        feedback: `${t("validation.text")} 255`,
        validation: {
          maxLength: 255,
        },
      },
      {
        id: "email",
        label: t("name.user.email"),
        type: "text",
        required: true,
        feedback: `${t("validation.text")} 255`,
        validation: {
          maxLength: 255,
        },
      },
    ],
    datePicker: [
      {
        name: "targetDate",
        label: t("name.brewery.targetDate"),
      },
    ],
  },
  calculator: [
    {
      id: "capacity",
      label: t("name.brewery.capacity"),
      type: "number",
      required: true,
      feedback: `${t("validation.number")} 0-100.000`,
      validation: {
        min: 0,
        max: 100000,
      },
    },
  ],
});

export default prospectOrderFieldsProvider;
