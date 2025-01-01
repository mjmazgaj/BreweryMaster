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
      orderQuantity: 0,
      describtion: "",
    });
  }

  const handleAddResereve = (quantityData) => {
    setShow(false);
    clear();
    console.log("Add Reserve");
    console.log(quantityData);
  };

  const handleEditResereve = (quantityData) => {
    setShow(false);
    clear();
    console.log("Edit reserve");
    console.log(quantityData);
  };

  const handleAddOrder = (quantityData) => {
    setShow(false);
    clear();
    console.log("Add order");
    console.log(quantityData);
  };

  const handleEditOrder = (quantityData) => {
    setShow(false);
    clear();
    console.log("Edit order");
    console.log(quantityData);
  };

  const actionCases = {
    addreserve: {
      title: `Add Reserve ${quantityData ? quantityData.name : ""}`,
      function: handleAddResereve,
      isReadOnly: true,
    },
    editreserve: {
      title: `Edit Reserve ${quantityData ? quantityData.name : ""}`,
      function: handleEditResereve,
      isReadOnly: true,
    },
    addorder: {
      title: `Add Order ${quantityData ? quantityData.name : ""}`,
      function: handleAddOrder,
      isReadOnly: true,
    },
    editorder: {
      title: `Edit Order ${quantityData ? quantityData.name : ""}`,
      function: handleEditOrder,
      isReadOnly: true,
    },
  };

  let actionObject = actionCases[`${action.verb}${action.area}`];

  return {
    handleClose,
    actionObject,
  };
};
