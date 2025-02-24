import React, {useState} from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalFormBasic } from "./helpers/useModalFormBasic";
import FormControls from "../FormControls";

import DropDownIndex from "../DropDownIndex";
import FormDatePicker from "../FormDatePicker";

const ModalFormBasic = ({
  fields,
  data,
  setData,
  show,
  setShow,
  modalCustomizationObject
}) => {

  const [isValid, setIsValid] = useState(true);

  const { handleClose, handleCheckBox, handleSelectChange, handleDateChange, handleFormSubmit } =
    useModalFormBasic({
      setData,
      setShow,
      isValid,
      modalCustomizationObject,
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
            checked={data && data[checkBoxObject.category] && data[checkBoxObject.category].includes(checkBoxObject.id)}
            onChange={(e) =>
              handleCheckBox(checkBoxObject.id, checkBoxObject.category, e.target.checked)
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
        <Form onSubmit={(event) => handleFormSubmit(event, data)}>
          <Modal.Header closeButton>
            <Modal.Title>{modalCustomizationObject?.title ?? ""}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <FormControls
              fields={fields.control}
              data={data}
              setData={setData}
              setIsValid={setIsValid}
            />
            {renderDropdowns()}
            {renderCheckBoxes()}
            {renderDatePickers()}
          </Modal.Body>
          <Modal.Footer>
            {modalCustomizationObject?.buttons &&
              modalCustomizationObject.buttons.map((button, index) => (
                <Button
                  type={button.isSubmit ? "submit" : ""}
                  key={index}
                  variant="dark"
                  disabled={!isValid}
                  onClick={button?.function ?? null}
                >
                  {button.label}
                </Button>
              ))}
          </Modal.Footer>
        </Form>
      </Modal>
    )
  );
};

export default ModalFormBasic;
