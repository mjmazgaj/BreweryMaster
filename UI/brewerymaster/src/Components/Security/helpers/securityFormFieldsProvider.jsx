const securityFormFieldsProvider = (t) => ({
    loginFields: [
      {
        id: "email",
        label: "email",
        type: "email",
      },
      {
        id: "password",
        label: "Hasło",
        type: "password",
      }
    ],
    userAuthInfo: [
      {
        id: "email",
        label: "Email",
        type: "email",
      },
      {
        id: "password",
        label: "Hasło",
        type: "password",
      },
      {
        id: "confirmPassword",
        label: "Powtórz hasło",
        type: "password",
      },
    ],
  
    address: [
      {
        id: "street",
        label: "Ulica",
        type: "text",
      },
      {
        id: "houseNumber",
        label: "Numer domu",
        type: "text",
      },
      {
        id: "apartamentNumber",
        label: "Numer mieszkania",
        type: "text",
      },
      {
        id: "postalCode",
        label: "Kod pocztowy",
        type: "text",
      },
      {
        id: "city",
        label: "Miasto",
        type: "text",
      },
      {
        id: "commune",
        label: "Gmina",
        type: "text",
      },
      {
        id: "region",
        label: "Region",
        type: "text",
      },
      {
        id: "country",
        label: "Kraj",
        type: "text",
      },
    ],
  
    individualUserInfo: [
      {
        id: "forename",
        label: "Imię",
        type: "text",
      },
      {
        id: "surname",
        label: "Nazwisko",
        type: "text",
      },
    ],
  
    companyUserInfo: [
      {
        id: "companyName",
        label: "Nazwa firmy",
        type: "text",
      },
      {
        id: "nip",
        label: "NIP",
        type: "text",
      },
      {
        id: "street",
        label: "Ulica (faktura)",
        type: "text",
      },
      {
        id: "houseNumber",
        label: "Numer domu (faktura)",
        type: "text",
      },
      {
        id: "apartamentNumber",
        label: "Numer mieszkania (faktura)",
        type: "text",
      },
      {
        id: "postalCode",
        label: "Kod pocztowy (faktura)",
        type: "text",
      },
      {
        id: "city",
        label: "Miasto (faktura)",
        type: "text",
      },
      {
        id: "commune",
        label: "Gmina (faktura)",
        type: "text",
      },
      {
        id: "region",
        label: "Region (faktura)",
        type: "text",
      },
      {
        id: "country",
        label: "Kraj (faktura)",
        type: "text",
      },
    ],
  });
  
  export default securityFormFieldsProvider;