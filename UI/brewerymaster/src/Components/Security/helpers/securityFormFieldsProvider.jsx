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
    registerFields: [
      {
        id: "email",
        label: "email",
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
      }
    ],
  });
  
  export default securityFormFieldsProvider;