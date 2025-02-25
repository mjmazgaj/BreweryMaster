export const useTaskCard = ({ setShowEditModal, setModalData }) => {
  const handleEditClick = (data) => {
    setModalData(data);
    setShowEditModal(true);
  };

  const handleRemoveClick = (id) => {
    console.log(`remove ${id}`);
  };

  return {
    handleEditClick,
    handleRemoveClick,
  };
};
