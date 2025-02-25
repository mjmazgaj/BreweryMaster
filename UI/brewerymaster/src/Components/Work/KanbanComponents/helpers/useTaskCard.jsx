export const useTaskCard = ({ setShowEditModal, setModalData }) => {
  const handleEditClick = (data) => {
    setModalData(data);
    setShowEditModal(true);
  };

  const handleRemoveClick = (id) => {
    console.log(`remove ${id}`);
  };

  const handleDetailClick = (id) => {
    console.log(`detail ${id}`);
  };

  return {
    handleEditClick,
    handleDetailClick,
    handleRemoveClick,
  };
};
