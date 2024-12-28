import { useTranslation } from 'react-i18next';

export const useModalReservation = ({
  data,
  setShow,
  action,
  itemName,
}) => {
  const { t } = useTranslation(); 

  const handleClose = () => {
    setShow(false);
  };

  const handleResereve = (data) => {
    setShow(false);
    console.log(data);
  };

  const actionCases = {
    reserve: {
      title: `${data ? data.name : ""} details`,
      function: handleResereve,
      isReadOnly: true,
    },
  };

  let actionObject = actionCases[action];

  return {
    handleClose,
    actionObject
  };
};