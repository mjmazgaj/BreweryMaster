import {updateWithoutBody} from '../../api'

export const useModalConfirmation = ({id, setShow, confirmationAction, path, refreshTableData}) => {

  const handleClose = () => {
    setShow(false);
  }

  const handleDelete = async () => {
    setShow(false);

    await updateWithoutBody(`${path}/Delete`, id)
    refreshTableData();
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