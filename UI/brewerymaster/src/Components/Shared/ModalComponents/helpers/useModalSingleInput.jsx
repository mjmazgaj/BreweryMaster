import { useTranslation } from "react-i18next";

export const useModalSingleInput = (
  modalData,
  handleConfirmQuantity,
  setModalData
) => {
  const { t } = useTranslation();

  const handleConfirmOnClick = () => {
    const quantity = parseInt(
      document.getElementById("quantityInput").value,
      10
    );
    if (quantity > 0 && quantity <= modalData.totalQuantity) {
      handleConfirmQuantity(quantity);
    } else {
      alert(t("message.invalidInput"));
    }
  };

  const handleCancelOnClick = () => {
    setModalData(null);
  };

  return {
    handleConfirmOnClick,
    handleCancelOnClick,
  };
};
