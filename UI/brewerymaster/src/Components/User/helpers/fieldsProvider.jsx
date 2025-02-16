const fieldsProvider = (t) => ({
    userInfoFields:{
        control: [
          {
            id: "forename",
            label: t("name.user.forename"),
            type: "textArea",
          },
          {
            id: "surname",
            label: t("name.user.surname"),
            type: "textArea",
          },
          {
            id: "email",
            label: t("name.user.email"),
            type: "textArea",
          },
        ],
    },
    addressInfoFields:{
        control: [
          {
            id: "street",
            label: t("name.user.street"),
            type: "textArea",
          },
          {
            id: "houseNumber",
            label: t("name.user.houseNumber"),
            type: "textArea",
          },
          {
            id: "apartamentNumber",
            label: t("name.user.apartamentNumber"),
            type: "textArea",
          },
          {
            id: "postalCode",
            label: t("name.user.postalCode"),
            type: "textArea",
          },
          {
            id: "city",
            label: t("name.user.city"),
            type: "textArea",
          },
          {
            id: "commune",
            label: t("name.user.commune"),
            type: "textArea",
          },
          {
            id: "country",
            label: t("name.user.country"),
            type: "textArea",
          },
        ],
    },
  });
  
  export default fieldsProvider;