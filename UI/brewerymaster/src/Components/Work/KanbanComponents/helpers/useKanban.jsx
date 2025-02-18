import { useEffect, useState } from "react";

import { updateStatus, fetchDataByOwnerId } from "../../api";

export const useKanban = ({
  columns,
  setColumns,
  setErrorMessage,
  setShowModal,
}) => {
  const [tasks, setTasks] = useState([]);

  useEffect(() => {
    const getData = () => {
      fetchDataByOwnerId(setColumns);
    };
    getData();
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

  const handleClose = async (e) => {
    e.preventDefault();
    setShowModal(false);
  };

  return {
    handleSave,
    handleAdd,
    handleClose,
  };
};
