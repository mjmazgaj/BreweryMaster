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
    clear();
  };

  const clear = () => {
    setReservationData({
      id: 0,
      name: "",
      reserveQuantity: 0,
      describtion: "",
    });
  }

  const handleResereve = (reservationData) => {
    setShow(false);
    clear();
    console.log("reserve");
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
