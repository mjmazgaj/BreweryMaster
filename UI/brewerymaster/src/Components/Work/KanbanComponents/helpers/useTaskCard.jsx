export const useTaskCard = ({
  setShowEditModal,
  setShowDeleteModal,
  setModalData,
}) => {
  const handleEditClick = (data) => {
    setModalData(data);
    setShowEditModal(true);
  };

  const handleRemoveClick = (data) => {
    setModalData((prevData) => ({
      ...prevData,
      title: data?.title,
      id: data?.id,
    }));
    setShowDeleteModal(true);
  };

  return {
    handleEditClick,
    handleRemoveClick,
  };
};
