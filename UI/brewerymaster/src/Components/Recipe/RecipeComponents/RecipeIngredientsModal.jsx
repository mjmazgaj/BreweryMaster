import React from "react";
import "../recipe.css"

import { Button, Form } from "react-bootstrap";

import { useTranslation } from 'react-i18next';
import { useRecipeModal } from "./helpers/useRecipeModal";

const RecipeIngredientsModal = ({modalData, handleConfirmQuantity, setModalData}) => {  
  const { t } = useTranslation(); 

  const {
    handleConfirmOnClick,
    handleCancelOnClick
  } = useRecipeModal(modalData, handleConfirmQuantity, setModalData);

  return (
    modalData && (
      <div className="recipe-ingredients-modal_container">
        <h4>Add {modalData.name}</h4>
        <p>Available: {modalData.maxQuantity}</p>
        <Form.Control
          type="number"
          min="1"
          max={modalData.maxQuantity}
          placeholder="Quantity"
          id="quantityInput"
        />
        <div className="recipe-ingredients-modal_buttons-container">
          <Button onClick={handleConfirmOnClick}>{t("button.confirm")}</Button>
          <Button onClick={handleCancelOnClick}>{t("button.cancel")}</Button>
        </div>
      </div>
    )
  );
};

export default RecipeIngredientsModal;