const securityFormFieldsProvider = (t) => ({
  loginFields: [
    {
      id: "email",
      label: "email",
      type: "email",
      required: true,
      feedback: `${t("validation.email")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "password",
      label: "Hasło",
      type: "password",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
  ],
  userAuthInfo: [
    {
      id: "email",
      label: "Email",
      type: "email",
      required: true,
      feedback: `${t("validation.email")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "password",
      label: "Hasło",
      type: "password",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        minLength: 8,
        maxLength: 255,
      },
    },
    {
      id: "confirmPassword",
      label: "Powtórz hasło",
      type: "password",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
  ],

  address: [
    {
      id: "street",
      label: "Ulica",
      type: "text",
      required: false,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "houseNumber",
      label: "Numer domu",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 10`,
      validation: {
        maxLength: 10,
      },
    },
    {
      id: "apartamentNumber",
      label: "Numer mieszkania",
      type: "text",
      required: false,
      feedback: `${t("validation.text")} 10`,
      validation: {
        maxLength: 10,
      },
    },
    {
      id: "postalCode",
      label: "Kod pocztowy",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 6`,
      validation: {
        maxLength: 6,
      },
    },
    {
      id: "city",
      label: "Miasto",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "commune",
      label: "Gmina",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "region",
      label: "Region",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "country",
      label: "Kraj",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
  ],

  individualUserInfo: [
    {
      id: "forename",
      label: "Imię",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "surname",
      label: "Nazwisko",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
  ],

  companyUserInfo: [
    {
      id: "companyName",
      label: "Nazwa firmy",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "nip",
      label: "NIP",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "street",
      label: "Ulica (faktura)",
      type: "text",
      required: false,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "houseNumber",
      label: "Numer domu (faktura)",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 10`,
      validation: {
        maxLength: 10,
      },
    },
    {
      id: "apartamentNumber",
      label: "Numer mieszkania (faktura)",
      type: "text",
      required: false,
      feedback: `${t("validation.text")} 10`,
      validation: {
        maxLength: 10,
      },
    },
    {
      id: "postalCode",
      label: "Kod pocztowy (faktura)",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 6`,
      validation: {
        maxLength: 6,
      },
    },
    {
      id: "city",
      label: "Miasto (faktura)",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "commune",
      label: "Gmina (faktura)",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "region",
      label: "Region (faktura)",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
    {
      id: "country",
      label: "Kraj (faktura)",
      type: "text",
      required: true,
      feedback: `${t("validation.text")} 255`,
      validation: {
        maxLength: 255,
      },
    },
  ],
});

export default securityFormFieldsProvider;
