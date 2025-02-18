const fieldsProvider = (t) => ({
  kanbanModalFields: {
    control: [
      {
        id: "title",
        label: t("name.kanban.title"),
        type: "text",
      },
      {
        id: "summary",
        label: t("name.kanban.summary"),
        type: "text",
      },
      {
        id: "status",
        label: t("name.kanban.status"),
        type: "number",
      },
      {
        id: "dueDate",
        label: t("name.kanban.dueDate"),
        type: "date",
      },
      {
        id: "ownerId",
        label: t("name.kanban.ownerId"),
        type: "number",
      },
      {
        id: "orderId",
        label: t("name.kanban.orderId"),
        type: "number",
      },
    ],
  },
});

export default fieldsProvider;
