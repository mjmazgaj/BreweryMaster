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
      }
    ],
    datePicker: [
      {
        name: "dueDate",
        label: t("name.brewery.dueDate"),
      },
    ],
  },
});

export default fieldsProvider;
