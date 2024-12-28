import React from 'react';
import { Modal, Button } from 'react-bootstrap';

import { useModalItemAction } from './helpers/useModalItemAction';
import FormControls from '../FormControls';

const ModalItemAction = ({
  fields,
  data,
  setData,
  show,
  setShow,
  setShowConfirmationModal,
  action,
  setAction,
  itemName
}) => {

  const { handleClose, handleDelete, actionObject } =
    useModalItemAction({
      data,
      setShow,
      setShowConfirmationModal,
      action,
      itemName,
    }); 


    const buttonsSet = {
      "default": (
        <>
          <Button variant="dark" onClick={() => setAction("edit")}>
            Edit
          </Button>
          <Button variant="dark" onClick={handleDelete}>
            Delete
          </Button>
        </>
      ),
      "summary": (
        <>
          <Button variant="dark" onClick={actionObject.function("reserve")}>
            Reserve
          </Button>
          <Button variant="dark" onClick={actionObject.function("order")}>
            Order
          </Button>
          <Button variant="dark" onClick={() => setAction("edit")}>
            Edit
          </Button>
          <Button variant="dark" onClick={handleDelete}>
            Delete
          </Button>
        </>
      ),
      "add": (
        <>
          <Button variant="dark" onClick={actionObject.function}>
            Add
          </Button>
        </>
      ),
      "edit": (
        <>
          <Button variant="dark" onClick={actionObject.function}>
            Save Changes
          </Button>
        </>
      ),
    };

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
          isReadOnly={actionObject.isReadOnly}
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
