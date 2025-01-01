import { useTranslation } from "react-i18next";

export const useModalQuantity = ({
  quantityData,
  setQuantityData,
  setShow,
  action,
}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
    clear();
  };

  const clear = () => {
    setQuantityData({
      id: 0,
      name: "",
      reserveQuantity: 0,
      describtion: "",
    });
  }

  const handleResereve = (quantityData) => {
    setShow(false);
    clear();
    console.log("Reserve");
    console.log(quantityData);
  };

  const handleOrder = (quantityData) => {
    setShow(false);
    clear();
    console.log("order");
    console.log(quantityData);
  };

  const actionCases = {
    addreserve: {
      title: `Add Reserve ${quantityData ? quantityData.name : ""}`,
      function: handleResereve,
      isReadOnly: true,
    },
    editreserve: {
      title: `Edit Reserve ${quantityData ? quantityData.name : ""}`,
      function: handleResereve,
      isReadOnly: true,
    },
    addorder: {
      title: `Add Order ${quantityData ? quantityData.name : ""}`,
      function: handleOrder,
      isReadOnly: true,
    },
    editorder: {
      title: `Edit Order ${quantityData ? quantityData.name : ""}`,
      function: handleOrder,
      isReadOnly: true,
    },
  };

  let actionObject = actionCases[`${action.verb}${action.area}`];

  return {
    handleClose,
    actionObject,
  };
};
