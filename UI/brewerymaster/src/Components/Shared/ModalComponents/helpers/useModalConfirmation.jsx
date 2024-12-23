export const useModalConfirmation = ({itemId, setShow, confirmationAction}) => {

  const handleClose = () => {
    setShow(false);
  }

  const handleDelete = () => {
    setShow(false);
    console.log(`delete ${itemId}`);
  };

  const confirmationCases = {
    delete: {
      title: "Do you want to delete the following item?",
      function: handleDelete,
    },
  };

  
  let confirmationObject = confirmationCases[confirmationAction];

  return {
    handleClose,
    confirmationObject
  };
};