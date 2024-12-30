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
    console.log("reserve");
    console.log(quantityData);
  };

  const handleOrder = (quantityData) => {
    setShow(false);
    clear();
    console.log("order");
    console.log(quantityData);
  };

  const actionCases = {
    reserve: {
      title: `Reserve ${quantityData ? quantityData.name : ""}`,
      function: handleResereve,
      isReadOnly: true,
    },
    order: {
      title: `Order ${quantityData ? quantityData.name : ""}`,
      function: handleOrder,
      isReadOnly: true,
    },
  };

  let actionObject = actionCases[action];

  return {
    handleClose,
    actionObject,
  };
};
