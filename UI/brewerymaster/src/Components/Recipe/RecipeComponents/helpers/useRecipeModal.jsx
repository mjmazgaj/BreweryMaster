import { useTranslation } from 'react-i18next';

export const useRecipeModal = (modalData, handleConfirmQuantity, setModalData) => {
  const { t } = useTranslation(); 

  const handleConfirmOnClick = () => {

    const quantity = parseInt(
      document.getElementById("quantityInput").value,
      10
    );
    if (quantity > 0 && quantity <= modalData.maxQuantity) {
      handleConfirmQuantity(quantity);
    } else {
      alert(t("recipe.invalidQuantity"));
    }
  }

  const handleCancelOnClick = () => {
    setModalData(null)
  }

  return {
    handleConfirmOnClick,
    handleCancelOnClick
  };
};