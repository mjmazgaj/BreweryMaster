import React, { useState, useEffect } from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalForm } from "./helpers/useModalForm";
import FormControls from "../FormControls";

import { useTranslation } from "react-i18next";
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
  const { t } = useTranslation();
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
      typeId: parseInt(value),
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
              id={"modal-form_dropdown"}
              data={types}
              selectedOption={data.typeId}
              setSelectedOption={handleSelectChange}
              isReadOnly={actionObject.isReadOnly}
              label="Type"
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
            <div className="modal-form_checkbox-container">
              <h5>{t("name.brewery.selectUnits")}</h5>
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
            {action == "add" ? t("button.add") : t("button.saveChanges")}
          </Button>
          <Button variant="dark" onClick={handleClose}>
            {t("button.close")}
          </Button>
        </Modal.Footer>
      </Form>
    </Modal>
  );
};

export default ModalForm;
