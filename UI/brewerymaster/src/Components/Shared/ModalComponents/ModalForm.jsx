import React, { useState, useEffect } from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalForm } from "./helpers/useModalForm";
import FormControls from "../FormControls";

import { fetchEntity } from "../api";
import DropDownIndex from "../DropDownIndex";

const ModalForm = ({
  fields,
  data,
  setData,
  types,
  show,
  setShow,
  action,
  itemName,
}) => {
  const [units, setUnits] = useState([]);
  const [isValid, setIsValid] = useState(true);

  const { handleClose, actionObject } = useModalForm({
    data,
    setShow,
    action,
    itemName,
    units,
    isValid,
  });

  useEffect(() => {
    fetchEntity("Unit", (fetchedUnits) => {
      const updatedUnits = fetchedUnits.map((unit) => ({
        ...unit,
        isUsed: unit.isUsed ?? false,
      }));
      setUnits(updatedUnits);
    });
  }, []);


  const handleCheckBox = (unit) => {
    setUnits((prevUnits) =>
      prevUnits.map((u) => (u.id === unit.id ? { ...u, isUsed: !u.isUsed } : u))
    );
  };

  const handleSelectChange = (e) => {
    const { value } = e.target;
    setData((prevData) => ({
      ...prevData,
      type: parseInt(value),
    }));
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Form onSubmit={(event) => actionObject.function(event, data)}>
        <Modal.Header closeButton>
          <Modal.Title>{actionObject.title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {types && (
            <DropDownIndex
              id={"modal-item-action_dropdown"}
              data={types}
              selectedOption={data.type}
              setSelectedOption={handleSelectChange}
              isReadOnly={actionObject.isReadOnly}
            />
          )}
          <FormControls
            fields={fields}
            data={data}
            setData={setData}
            isReadOnly={actionObject.isReadOnly}
            setIsValid={setIsValid}
          />
          {action == "add" && units && (
            <div className="">
              {units.map((unit) => (
                <Form.Check
                    type="switch"
                    id={`${unit.id}`}
                    label={unit.name}
                    checked={unit.isUsed}
                    onChange={() => handleCheckBox(unit)}
                  />
              ))}
            </div>
          )}
        </Modal.Body>
        <Modal.Footer>
          <Button type="submit" variant="dark" disabled={!isValid}>
            {action == "add" ? "Add" : "Save Changes"}
          </Button>
          <Button variant="dark" onClick={handleClose}>
            Close
          </Button>
        </Modal.Footer>
      </Form>
    </Modal>
  );
};

export default ModalForm;
