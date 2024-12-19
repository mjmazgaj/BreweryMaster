import React from "react";
import "../shared.css"

import { Button, Form } from "react-bootstrap";

import { useTranslation } from 'react-i18next';
import { useModalSingleInput } from "./helpers/useModalSingleInput";

const ModalSingleInput = ({modalData, handleConfirmQuantity, setModalData}) => {  
  const { t } = useTranslation(); 

  const {
    handleConfirmOnClick,
    handleCancelOnClick
  } = useModalSingleInput(modalData, handleConfirmQuantity, setModalData);

  return (
    modalData && (
      <div className="modal-single-input_container">
          <h4>Add {modalData.name}</h4>
          <p>Available: {modalData.maxQuantity}</p>
          <Form.Control
            type="number"
            min="1"
            max={modalData.maxQuantity}
            placeholder="Quantity"
            id="quantityInput"
          />
          <div className="modal-single-input_buttons-container">
            <Button variant="dark" onClick={handleConfirmOnClick}>
              {t("button.confirm")}
            </Button>
            <Button variant="dark" onClick={handleCancelOnClick}>
              {t("button.cancel")}
            </Button>
        </div>
      </div>
    )
  );
};

export default ModalSingleInput