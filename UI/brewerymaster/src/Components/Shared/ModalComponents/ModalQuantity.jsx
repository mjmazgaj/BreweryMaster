import React, { useState, useEffect } from 'react';
import { Modal, Button } from 'react-bootstrap';

import { useModalQuantity } from './helpers/useModalQuantity';
import FormControls from '../FormControls';

const ModalQuantity = ({
  fields,
  modalData,
  show,
  setShow,
  action,
  isEmpty
}) => {

  const [isValid, setIsValid] = useState(true);
  const [quantityData, setQuantityData] = useState({});

  const { 
    handleClose,
    actionObject } = useModalQuantity({
      quantityData,
      setQuantityData,
      setShow,
      action,
  });

  useEffect(() => {
    setQuantityData(() => ({
      id: modalData.id,
      name: modalData.name,
      reserveQuantity: isEmpty ? "" : modalData.reserveQuantity,
      orderQuantity: isEmpty ? "" : modalData.orderQuantity,
      describtion: isEmpty ? "" : modalData.describtion,
    }));
  }, [modalData]);

  return actionObject ? (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{actionObject.title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <FormControls
          fields={fields}
          data={quantityData}
          setData={setQuantityData}
          setIsValid={setIsValid}
        />
      </Modal.Body>
      <Modal.Footer>
        <Button
          variant="dark"
          onClick={() => actionObject.function(quantityData)}
        >
          Save Changes
        </Button>
        <Button variant="dark" onClick={handleClose}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
  ) : (
    <></>
  );
};

export default ModalQuantity;
