import React from 'react';
import { Modal, Button } from 'react-bootstrap';

import { useModalConfirmation } from './helpers/useModalConfirmation';

import { useTranslation } from "react-i18next";
const ModalConfirmation = ({ id, name, confirmationAction, show, setShow, path, refreshTableData}) => {
  const { t } = useTranslation();

  const { handleClose, confirmationObject } = useModalConfirmation(
    {id, setShow, confirmationAction, path, refreshTableData}
  );

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{confirmationObject.title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <p>{name}</p>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="dark" onClick={confirmationObject.function}>
        {t("button.confirm")}
        </Button>
        <Button variant="dark" onClick={handleClose}>
        {t("button.close")}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalConfirmation;
