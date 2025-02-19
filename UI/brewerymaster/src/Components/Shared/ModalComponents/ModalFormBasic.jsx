import React, { useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalForm } from "./helpers/useModalForm";
import FormControls from "../FormControls";

import { useTranslation } from "react-i18next";
import DropDownIndex from "../DropDownIndex";
import FormDatePicker from "../FormDatePicker";

const ModalFormBasic = ({
  fields,
  data,
  setData,
  show,
  setShow,
  action,
  itemName,
  path,
  refreshTableData,
}) => {
  const { t } = useTranslation();
  const [isValid, setIsValid] = useState(true);
  const [usedUnits, setUsedUnits] = useState([]);

  const {
    handleClose,
    actionObject,
    handleCheckBox,
    handleSelectChange,
    handleDateChange,
  } = useModalForm({
    data,
    setData,
    usedUnits,
    setUsedUnits,
    show,
    setShow,
    action,
    itemName,
    isValid,
    path,
    refreshTableData,
  });

  const renderDropdowns = () =>
    fields?.dropdown && (
      <div className="modal-form_dropdown-container">
        <hr />
        {fields.dropdown.map((dropdownObject, index) => (
          <DropDownIndex
            key={index}
            id={"modal-form_dropdown"}
            data={dropdownObject.data}
            selectedOption={data[dropdownObject.name]}
            setSelectedOption={(e) =>
              handleSelectChange(e, dropdownObject.name)
            }
            isReadOnly={actionObject.isReadOnly}
            label={dropdownObject.label}
          />
        ))}
      </div>
    );

  const renderCheckBoxes = () =>
    fields?.checkBox && (
      <div className="modal-form_checkbox-container">
        <hr />
        {fields.checkBox.map((checkBoxObject) => (
          <Form.Check
            type="switch"
            key={checkBoxObject.id}
            id={checkBoxObject.name}
            label={checkBoxObject.label}
            checked={
              usedUnits.includes(checkBoxObject.id) ||
              data.units?.includes(checkBoxObject.id)
            }
            disabled={usedUnits.includes(checkBoxObject.id)}
            onChange={(e) =>
              handleCheckBox(checkBoxObject.id, e.target.checked)
            }
          />
        ))}
      </div>
    );

  const renderDatePickers = () =>
    fields?.datePicker && (
      <div className="modal-form_datepicker-container">
        <hr />
        {fields.datePicker.map((datePickerObject) => (
          <FormDatePicker
            key={datePickerObject.name}
            id={`datepicker-${datePickerObject.name}`}
            label={datePickerObject.label}
            selectedDate={data[datePickerObject.name]}
            setSelectedDate={(date) =>
              handleDateChange(date, datePickerObject.name)
            }
          />
        ))}
      </div>
    );

  return (
    fields && (
      <Modal show={show} onHide={handleClose}>
        <Form onSubmit={(event) => actionObject.function(event, data)}>
          <Modal.Header closeButton>
            <Modal.Title>{actionObject.title}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <FormControls
              fields={fields.control}
              data={data}
              setData={setData}
              isReadOnly={actionObject.isReadOnly}
              setIsValid={setIsValid}
            />
            {renderDropdowns()}
            {renderCheckBoxes()}
            {renderDatePickers()}
          </Modal.Body>
          <Modal.Footer>
            <Button type="submit" variant="dark" disabled={!isValid}>
              {action == "Add" ? t("button.add") : t("button.saveChanges")}
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
