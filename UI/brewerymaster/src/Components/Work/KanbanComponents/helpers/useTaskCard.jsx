export const useTaskCard = () => {
  const handleEditClick = (id) => {
    console.log(`edit ${id}`);
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
  }
}
