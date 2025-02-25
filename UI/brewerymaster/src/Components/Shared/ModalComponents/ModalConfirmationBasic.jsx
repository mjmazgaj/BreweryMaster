import React from "react";
import { Modal, Button } from "react-bootstrap";

import { useTranslation } from "react-i18next";
const ModalConfirmationBasic = ({
  show,
  setShow,
  modalCustomizationObject,
}) => {
  const { t } = useTranslation();

  const handleClose = () => {
    setShow(false);
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{modalCustomizationObject.title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <p>{modalCustomizationObject.name}</p>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="dark" onClick={modalCustomizationObject.function}>
          {t("button.confirm")}
        </Button>
        <Button variant="dark" onClick={handleClose}>
          {t("button.close")}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalConfirmationBasic;
