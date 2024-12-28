import React from 'react';
import { Modal, Button } from 'react-bootstrap';

import { useModalReservation } from './helpers/useModalReservation';
import FormControls from '../FormControls';

const ModalReservation = ({
  fields,
  data,
  setData,
  show,
  setShow,
  action,
  itemName,
}) => {
  const { 
    handleClose,
    actionObject } = useModalReservation({
      data,
      setShow,
      action,
      itemName,
  });

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{actionObject.title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <FormControls
          fields={fields}
          data={data}
          setData={setData}
        />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="dark" onClick={() => actionObject.function(data)}>
          Save Changes
        </Button>
        <Button variant="dark" onClick={handleClose}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalReservation;
