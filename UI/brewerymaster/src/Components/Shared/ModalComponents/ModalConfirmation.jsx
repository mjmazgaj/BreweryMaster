import React from 'react';
import { Modal, Button } from 'react-bootstrap';

import { useModalConfirmation } from './helpers/useModalConfirmation';

const ModalConfirmation = ({ data, confirmationAction, show, setShow }) => {

  const { handleClose, confirmationObject } = useModalConfirmation(
    {data, setShow, confirmationAction}
  );

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{confirmationObject.title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <p>{data.name}</p>
      </Modal.Body>
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

export default ModalConfirmation;
