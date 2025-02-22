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
    ],
    datePicker: [
      {
        name: "dueDate",
        label: t("name.brewery.dueDate"),
      },
    ],
  },
  filterFields: {
    control: [
      {
        id: "createdById",
        label: t("name.kanban.createdById"),
        type: "text",
      },
      {
        id: "assignedToId",
        label: t("name.kanban.assignedToId"),
        type: "text",
      },
      {
        id: "orderId",
        label: t("name.kanban.orderId"),
        type: "text",
      },
    ]
  },
});

export default fieldsProvider;
