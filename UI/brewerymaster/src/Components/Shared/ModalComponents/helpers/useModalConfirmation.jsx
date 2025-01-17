export const useModalConfirmation = ({id, setShow, confirmationAction}) => {

  const handleClose = () => {
    setShow(false);
  }

  const handleDelete = () => {
    setShow(false);
    console.log(`delete ${id}`);
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