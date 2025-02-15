import {updateWithoutBody} from '../../api'

export const useModalConfirmation = ({id, setShow, confirmationAction, path}) => {

  const handleClose = () => {
    setShow(false);
  }

  const handleDelete = async () => {
    setShow(false);
    console.log(path);
    console.log(`delete ${id}`);

    await updateWithoutBody(`${path}/Delete`, id)
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