import React, { useState, useEffect } from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalItemAction } from "./helpers/useModalItemAction";
import FormControls from "../FormControls";

import { fetchEntity } from "../api";
import DropDownIndex from "../DropDownIndex";

const ModalItemAction = ({
  fields,
  data,
  types,
  setData,
  show,
  setShow,
  setShowConfirmationModal,
  setShowQuantityModal,
  setQuantityAction,
  action,
  setAction,
  itemName,
}) => {  
  const [units, setUnits] = useState([]);

  const { handleClose, handleDelete, actionObject } = useModalItemAction({
    data,
    setShow,
    setShowConfirmationModal,
    setShowQuantityModal,
    setQuantityAction,
    action,
    itemName,
    units
  });


  const buttonsSet = {
    default: (
      <>
        <Button variant="dark" onClick={() => setAction("edit")}>
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
        <Button variant="dark" onClick={() => setAction("edit")}>
          Edit
        </Button>
        <Button variant="dark" onClick={handleDelete}>
          Delete
        </Button>
      </>
    ),
    add: (
      <>
        <Button variant="dark" onClick={actionObject.function(data)}>
          Add
        </Button>
      </>
    ),
    edit: (
      <>
        <Button variant="dark" onClick={actionObject.function(data)}>
          Save Changes
        </Button>
      </>
    ),
  };

  useEffect(() => {
    fetchEntity("Unit", setUnits);
  }, []);

  const handleCheckBox = (unit) => {
    setUnits((prevUnits) =>
      prevUnits.map((u) =>
        u.id === unit.id ? { ...u, isUsed: !u.isUsed } : u
      )
    );
  }

  const handleSelectChange = (e) => {
    const { value } = e.target;
    setData((prevData) => ({
      ...prevData,
      type: value,
    }));
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{actionObject.title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {types ? (
          <DropDownIndex
            id={1}
            data={types}
            selectedOption={data.type}
            setSelectedOption={handleSelectChange}
            isReadOnly={actionObject.isReadOnly}
          />
        ) : (
          <></>
        )}
        <FormControls
          fields={fields}
          data={data}
          setData={setData}
          isReadOnly={actionObject.isReadOnly}
        />
        {action == "add" && units ? (
          <div className="">
            {units.map((unit) => (
              <div key={unit.id}>
                <Form.Check
                  type="switch"
                  id={`${unit.id}`}
                  label={unit.name}
                  checked={unit.isUsed}
                  onClick={() => handleCheckBox(unit)}
                />
              </div>
            ))}
          </div>
        ) : (
          <></>
        )}
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
