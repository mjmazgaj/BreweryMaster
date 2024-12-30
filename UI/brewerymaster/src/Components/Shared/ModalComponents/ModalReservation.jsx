import React, { useState, useEffect } from 'react';
import { Modal, Button } from 'react-bootstrap';

import { useModalReservation } from './helpers/useModalReservation';
import FormControls from '../FormControls';

const ModalReservation = ({
  fields,
  modalData,
  show,
  setShow,
  action,
}) => {

  const [reservationData, setReservationData] = useState({});

  const { 
    handleClose,
    actionObject } = useModalReservation({
      reservationData,
      setReservationData,
      setShow,
      action,
  });


  useEffect(() => {
    setReservationData((prevData) => ({
      id: modalData.id,
      name: modalData.name,
      reserveQuantity: prevData?.reserveQuantity ?? 0,
      describtion: prevData?.describtion ?? "",
    }));
  }, [modalData]);

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{actionObject.title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <FormControls
          fields={fields}
          data={reservationData}
          setData={setReservationData}
        />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="dark" onClick={() => actionObject.function(reservationData)}>
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
