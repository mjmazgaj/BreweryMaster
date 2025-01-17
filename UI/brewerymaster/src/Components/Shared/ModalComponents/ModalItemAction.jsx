import React, { useState, useEffect } from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalItemAction } from "./helpers/useModalItemAction";
import FormControlsReadOnly from "../FormControlsReadOnly";

import { fetchEntity } from "../api";

const ModalItemAction = ({
  fields,
  data,
  show,
  setShow,
  setShowConfirmationModal,
  setShowQuantityModal,
  setShowModalForm,
  setModalAction,
  setQuantityAction,
  action,
  setAction,
}) => {
  const [units, setUnits] = useState([]);

  const { handleClose, handleDelete, handleEdit,  actionObject } = useModalItemAction({
    data,
    setShow,
    setShowConfirmationModal,
    setShowQuantityModal,
    setShowModalForm,
    setModalAction,
    setQuantityAction,
    action
  });

  const buttonsSet = {
    default: (
      <>
        <Button variant="dark" onClick={handleEdit}>
          Edit
        </Button>
        <Button variant="dark" onClick={handleDelete}>
          Delete
        </Button>
      </>
    ),
    summary: (
      <>
        <Button variant="dark" onClick={actionObject.function(data, "reserve")}>
          Reserve
        </Button>
        <Button variant="dark" onClick={actionObject.function(data, "order")}>
          Order
        </Button>
        <Button variant="dark" onClick={handleEdit}>
          Edit
        </Button>
        <Button variant="dark" onClick={handleDelete}>
          Delete
        </Button>
      </>
    )
  };

  useEffect(() => {
    fetchEntity("Unit", setUnits);
  }, []);

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{actionObject.title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
          <FormControlsReadOnly
            fields={fields}
            data={data}
          />
      </Modal.Body>
      <Modal.Footer>
        {buttonsSet[action]}
        <Button variant="dark" onClick={handleClose}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalItemAction;
