const fieldsProvider = (t) => ({
    orderGeneralInfoFields:{
        control: [
          {
            id: "capacity",
            label: t("name.brewery.capacity"),
            type: "textArea",
          },
          {
            id: "container",
            label: t("name.brewery.container"),
            type: "textArea",
          },
          {
            id: "price",
            label: t("name.brewery.price"),
            type: "textArea",
          },
          {
            id: "targetDate",
            label: t("name.brewery.targetDate"),
            type: "textArea",
          },
          {
            id: "createdOn",
            label: t("name.brewery.createdOn"),
            type: "textArea",
          },
          {
            id: "createdBy",
            label: t("name.brewery.createdBy"),
            type: "textArea",
          },
          {
            id: "status",
            label: t("name.brewery.status"),
            type: "textArea",
          },
        ],
    },
  });
  
  export default fieldsProvider;

  