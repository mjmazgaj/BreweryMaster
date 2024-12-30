import { useTranslation } from "react-i18next";

export const useModalReservation = ({
  reservationData,
  setReservationData,
  setShow,
  action,
}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
  };

  const handleResereve = (reservationData) => {
    setShow(false);
    setReservationData({
      id: 0,
      name: "",
      reserveQuantity: 0,
      describtion: "",
    });
    console.log(reservationData);
  };

  const actionCases = {
    reserve: {
      title: `${reservationData ? reservationData.name : ""} details`,
      function: handleResereve,
      isReadOnly: true,
    },
  };

  let actionObject = actionCases[action];

  return {
    handleClose,
    actionObject,
  };
};
