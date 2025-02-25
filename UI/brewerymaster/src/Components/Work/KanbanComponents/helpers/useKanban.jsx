import { useEffect, useState } from "react";

import { useTranslation } from "react-i18next";

import {
  addData,
  fetchData,
  updateWithoutParameter,
  apiEndpoints,
  updateData,
} from "../../../Shared/api";

import { createPath } from "../../../Shared/helpers/useObjectHelper";
import kanbanFieldsProvider from "./kanbanFieldsProvider";

export const useKanban = ({
  columns,
  setColumns,
  setShowAddModal,
  setModalData,
}) => {
  const { t } = useTranslation();
  const [tasks, setTasks] = useState([]);
  const [users, setUsers] = useState([]);
  const [orders, setOrders] = useState([]);

  const fillKanbanBoard = (data) => {
    let query = {
      CreatedById: data?.createdById,
      AssignedToId: data?.assignedToId,
      OrderId: data?.orderId,
    };

    const path = createPath(apiEndpoints.task, query);

    fetchData(path, setColumns);
  };

  const handleSave = async (e) => {
    e.preventDefault();
    updateWithoutParameter(apiEndpoints.taskEditStatus, tasks);
  };

  const handleAdd = async (e) => {
    e.preventDefault();
    setModalData({});
    setShowAddModal(true);
  };

  const addModalObject = {
    submitFunction: (data) => addData(apiEndpoints.task, data),
    buttons: [
      {
        isSubmit: false,
        label: t("button.add"),
      },
    ],
    title: t("work.addTask"),
  };

  const editModalObject = {
    submitFunction: async (data) => {
      await updateData(apiEndpoints.task, data.id, data);
      fillKanbanBoard({});
    },
    buttons: [
      {
        isSubmit: false,
        label: t("button.save"),
      },
    ],
    title: t("work.editTask"),
  };

  const editModalFields = {
    control: kanbanFieldsProvider(t).modalFields.control,
    dropdown: [
      {
        data: users,
        name: "assignedToId",
        label: t("name.kanban.assignedToId"),
      },
    ],
  }

  const filterObject = {
    submitFunction: fillKanbanBoard,
    buttons: [
      {
        isSubmit: true,
        label: t("button.filter"),
      },
    ],
    classNamePrefix: "kanban-filter",
  };

  const filterFields = {
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
      },
    ],
  };

  useEffect(() => {
    fillKanbanBoard({});
    fetchData(apiEndpoints.orderDropDown, setOrders);
    fetchData(apiEndpoints.userDropDown, setUsers);
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
    addModalObject,
    editModalObject,
    editModalFields,
    filterObject,
    filterFields,
  };
};
