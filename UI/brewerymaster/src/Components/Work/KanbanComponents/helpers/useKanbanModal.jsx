import { addData } from "../../../Shared/api";

export const useKanbanModal = ({ modalData, setShow, setErrorMessage }) => {
  const handleUpdate = async (e) => {
    e.preventDefault();

    const task = {
      Title: modalData.title,
      Summary: modalData.summary,
      Status: modalData.status,
      DueDate: modalData.dueDate,
      OwnerId: modalData.ownerId,
      OrderId: modalData.orderId,
    };

    try {
      await addData("task", task);
      setShow(false);
      window.location.reload();
    } catch (error) {
      setErrorMessage(
        error.response?.data?.message ||
          "Zapisanie nie powiodło się. Spróbuj ponownie."
      );
    }
  };

  return {
    handleUpdate,
  };
};
