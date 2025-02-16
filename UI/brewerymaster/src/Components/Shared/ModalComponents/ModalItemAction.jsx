import React, { useState, useEffect } from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalItemAction } from "./helpers/useModalItemAction";
import FormControlsReadOnly from "../FormControlsReadOnly";

import { fetchData } from "../api";

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
        <Button variant="dark" onClick={actionObject.function(data, "storage", "Increase")}>
        Increase
        </Button>
        <Button variant="dark" onClick={actionObject.function(data, "storage", "Reduce")}>
          Reduce
        </Button>
        <Button variant="dark" onClick={actionObject.function(data, "reservation")}>
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
    fetchData("Entity/Unit", setUnits);
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
