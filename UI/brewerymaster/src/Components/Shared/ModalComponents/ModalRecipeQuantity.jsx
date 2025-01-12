import React, { useState, useEffect } from 'react';
import { Modal, Button } from 'react-bootstrap';

import { useModalRecipeQuantity } from './helpers/useModalRecipeQuantity';
import FormControls from '../FormControls';

const ModalRecipeQuantity = ({
  fields,
  modalData,
  setSelectedData,
  show,
  setShow,
  action,
  isEmpty
}) => {

  const [isValid, setIsValid] = useState(true);
  const [quantityData, setQuantityData] = useState({});

  const { 
    handleClose,
    actionObject } = useModalRecipeQuantity({
      quantityData,
      setQuantityData,
      setSelectedData,
      setShow,
      action,
  });

  useEffect(() => {
    setQuantityData(() => ({
      id: modalData.id,
      name: modalData.name,
      quantity: isEmpty ? "" : modalData.quantity
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

export default ModalRecipeQuantity;
