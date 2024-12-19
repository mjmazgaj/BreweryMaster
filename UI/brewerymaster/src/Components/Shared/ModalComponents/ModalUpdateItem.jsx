import React from 'react';
import { Modal, Button } from 'react-bootstrap';

import FormControls from '../FormControls';

import { useModalUpdateItem } from './helpers/useModalUpdateItem';

const ModalUpdateItem = ({
  title,
  show,
  setShow,
  fields,
  data,
  setData,
  isUpdateMode
}) => {

  const { handleCloseOnClick, handleConfirmOnClick } = useModalUpdateItem(data, setShow); 

  return (
    <Modal show={show} onHide={handleCloseOnClick}>
      <Modal.Header closeButton>
        <Modal.Title>
          {isUpdateMode ? "Modify" : "Add"} {title}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <FormControls
          fields={fields}
          data={data}
          setData={setData}
        />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="dark" onClick={handleCloseOnClick}>
          Close
        </Button>
        <Button variant="dark" onClick={handleConfirmOnClick}>
          {isUpdateMode ? "Save Changes" : "Add"}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalUpdateItem;
