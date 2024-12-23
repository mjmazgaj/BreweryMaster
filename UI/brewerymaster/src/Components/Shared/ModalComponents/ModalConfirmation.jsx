import React from 'react';
import { Modal, Button } from 'react-bootstrap';

import { useModalConfirmation } from './helpers/useModalConfirmation';

const ModalUpdateItem = ({ itemId, confirmationAction, show, setShow }) => {

  const { handleClose, confirmationObject } = useModalConfirmation(
    {itemId, setShow, confirmationAction}
  );

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>
          {confirmationObject.title}
        </Modal.Title>
      </Modal.Header>
      <Modal.Footer>
        <Button variant="dark" onClick={confirmationObject.function}>
          Confirm
        </Button>
        <Button variant="dark" onClick={handleClose}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalUpdateItem;
