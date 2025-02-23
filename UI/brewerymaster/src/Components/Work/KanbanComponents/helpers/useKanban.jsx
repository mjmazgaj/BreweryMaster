import { useEffect, useState } from "react";

import { useTranslation } from "react-i18next";
import { updateStatus, fetchDataByOwnerId } from "../../api";

import { addData, fetchData } from "../../../Shared/api";
import { createPath } from "../../../Shared/helpers/useObjectHelper";
import fieldsProvider from "./fieldsProvider";

export const useKanban = ({
  columns,
  setColumns,
  setErrorMessage,
  setShowModal,
}) => {
  const { t } = useTranslation();
  const [tasks, setTasks] = useState([]);
  const [users, setUsers] = useState([]);
  const [orders, setOrders] = useState([]);

  const fillKanbanBoard = (data) =>{
    let query = {
      CreatedById: data?.createdById,
      AssignedToId: data?.assignedToId,
      OrderId: data?.orderId,
    };

    const path = createPath("Task", query);

    fetchData(path, setColumns);
  }
  
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

  const filterObject = {
    submitFunction: fillKanbanBoard,
    buttons: [
      {
        isSubmit: true,
        label: t("button.filter"),
      },
    ],
    classNamePrefix: "kanban-filter"
  };

  const filterFields = {
    constrol: fieldsProvider(t).filterFields.control,
    dropdown: [
      {
        data: users,
        name: "createdById",
        label: t("name.kanban.createdById"),
      },
      {
        data: users,
        name: "assignedToId",
        label: t("name.kanban.assignedToId"),
      },
      {
        data: orders,
        name: "orderId",
        label: t("name.brewery.order"),
      }
    ]
  }
  
  useEffect(() => {
    fillKanbanBoard({});
    fetchData("Order/DropDown", setOrders);
    fetchData("User/DropDown", setUsers);
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

  return {
    handleSave,
    handleAdd,
    modalCustomizationObject,
    filterObject,
    filterFields
  };
};
