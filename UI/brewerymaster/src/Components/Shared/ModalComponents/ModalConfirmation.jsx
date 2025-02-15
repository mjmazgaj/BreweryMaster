import React from 'react';
import { Modal, Button } from 'react-bootstrap';

import { useModalConfirmation } from './helpers/useModalConfirmation';

const ModalConfirmation = ({ id, name, confirmationAction, show, setShow, path}) => {

  const { handleClose, confirmationObject } = useModalConfirmation(
    {id, setShow, confirmationAction, path}
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
