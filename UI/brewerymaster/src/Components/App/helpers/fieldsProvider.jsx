const fieldsProvider = (t) => ({
  passwordModalFields: {
    control: [
      {
        id: "currentPassword",
        label: t("name.user.currentPassword"),
        type: "password",
        required: true,
        feedback: `${t("validation.text")} 255`,
        validation: {
          maxLength: 255,
        },
      },
      {
        id: "password",
        label: t("name.user.password"),
        type: "password",
        required: true,
        feedback: `${t("validation.text")} 255`,
        validation: {
          maxLength: 255,
        },
      },
      {
        id: "confirmPassword",
        label: t("name.user.confirmPassword"),
        type: "password",
        required: true,
        feedback: `${t("validation.text")} 255`,
        validation: {
          maxLength: 255,
        },
      },
    ],
  },
});

export default fieldsProvider;
