import React, { useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalFormBasic } from "./helpers/useModalFormBasic";
import FormControls from "../FormControls";

import { useTranslation } from "react-i18next";
import DropDownIndex from "../DropDownIndex";

const ModalFormBasic = ({
  fields,
  data,
  setData,
  show,
  setShow,
  action,
  itemName,
}) => {
  const { t } = useTranslation();
  const [isValid, setIsValid] = useState(true);

  const { handleClose, actionObject, handleCheckBox, handleSelectChange } = useModalFormBasic({
    data,
    setData,
    setShow,
    action,
    itemName,
    isValid,
  });

  const renderDropdowns = () =>
    fields.dropdown &&
    fields.dropdown.map((dropdownObject, index) => (
      <DropDownIndex
        key={index}
        id={"modal-form_dropdown"}
        data={dropdownObject.data}
        selectedOption={data[dropdownObject.name]}
        setSelectedOption={(e) => handleSelectChange(e, dropdownObject.name)}
        isReadOnly={actionObject.isReadOnly}
        label={dropdownObject.label}
      />
    ));

  const renderCheckBoxes = () =>(
    fields.checkBox && (
      <div className="modal-form_checkbox-container">
        {fields.checkBox.map((checkBoxObject) => (
          <Form.Check
            type="switch"
            key={checkBoxObject.id}
            id={checkBoxObject.name}
            label={checkBoxObject.label}
            checked={data[checkBoxObject.name]}
            onChange={() => handleCheckBox(checkBoxObject)}
          />
        ))}
      </div>
    )
  )
  
  return (
    fields && (
      <Modal show={show} onHide={handleClose}>
        <Form onSubmit={(event) => actionObject.function(event, data)}>
          <Modal.Header closeButton>
            <Modal.Title>{actionObject.title}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            {renderDropdowns()}
            <FormControls
              fields={fields.control}
              data={data}
              setData={setData}
              isReadOnly={actionObject.isReadOnly}
              setIsValid={setIsValid}
            />
            {renderCheckBoxes()}
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
    )
  );
};

export default ModalFormBasic;
