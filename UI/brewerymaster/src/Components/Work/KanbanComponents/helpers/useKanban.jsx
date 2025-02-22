import { useEffect, useState } from "react";

import { useTranslation } from "react-i18next";
import { updateStatus, fetchDataByOwnerId } from "../../api";

import { addData, fetchData } from "../../../Shared/api";
import { createPath } from "../../../Shared/helpers/useObjectHelper";

export const useKanban = ({
  columns,
  setColumns,
  setErrorMessage,
  setShowModal,
}) => {
  const { t } = useTranslation();
  const [tasks, setTasks] = useState([]);

  useEffect(() => {
    fillKanbanBoard({})

  }, []);

  useEffect(() => {
    if (columns) {
      const resultList = [];

      for (const key in columns) {
        if (columns.hasOwnProperty(key)) {
          const obj = columns[key];
          const status = obj.status;
          obj.items.forEach((item) => {
            const newItem = {
              Id: item.id,
              Status: status,
            };
            resultList.push(newItem);
          });
        }
      }

      setTasks(resultList);
    }
  }, [columns]);

  const handleSave = async (e) => {
    e.preventDefault();
    try {
      await updateStatus(tasks);
    } catch (error) {
      setErrorMessage(
        error.response?.data?.message ||
          "Zapisanie nie powiodło się. Spróbuj ponownie."
      );
    }
  };

  const handleAdd = async (e) => {
    e.preventDefault();
    setShowModal(true);
  };

  const modalCustomizationObject = {
    submitFunction: (data) => addData("Task", data),
    buttons: [
      {
        isSubmit: false,
        label: t("button.save"),
      },
    ],
    title: t("work.editTask"),
  };

  
  const fillKanbanBoard = (data) =>{
    console.log(data)
    let query = {
      CreatedById: data?.createdById,
      AssignedToId: data?.assignedToId,
      OrderId: data?.orderId,
    };

    const path = createPath("Task", query);

    console.log(path);
    fetchData(path, setColumns);
  }

  const formCustomizationObject = {
    submitFunction: fillKanbanBoard,
    buttons: [
      {
        isSubmit: true,
        label: t("button.filter"),
      },
    ],
    title: t("work.filter"),
    classNamePrefix: "kanban-filter"
  };

  return {
    handleSave,
    handleAdd,
    modalCustomizationObject,
    formCustomizationObject
  };
};
