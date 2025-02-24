const kanbanFieldsProvider = (t) => ({
  modalFields: {
    control: [
      {
        id: "title",
        label: t("name.kanban.title"),
        type: "text",
        required: true,
        feedback: `${t("validation.text")} 255`,
        validation: {
          maxLength: 255,
        },
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
});

export default kanbanFieldsProvider;
