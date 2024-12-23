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
          isReadOnly={action == "default" ? true : false}
        />
      </Modal.Body>
      <Modal.Footer>
        {action == "default" ? (
          <>
            <Button variant="dark" onClick={handleDelete}>
              Delete
            </Button>
            <Button variant="dark" onClick={() => setAction("edit")}>
              Edit
            </Button>
          </>
        ) : (
          <div>
            <Button variant="dark" onClick={actionObject.function}>
              Confirm
            </Button>
          </div>
        )}
        <Button variant="dark" onClick={handleClose}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalItemAction;
