import React, { Fragment, useState } from "react";
import { Form } from "react-bootstrap";

import { useModalForm } from "./helpers/useModalForm";

import FormControls from "../FormControls";
import DropDownIndex from "../DropDownIndex";
import FormDatePicker from "../FormDatePicker";

const FormBasic = ({ fields, data, setData }) => {
  const [isValid, setIsValid] = useState(true);

  const { handleCheckBox, handleSelectChange, handleDateChange } = useModalForm(
    {
      setData,
    }
  );

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
            checked={data.units?.includes(checkBoxObject.id)}
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
      <Fragment>
        <FormControls
          fields={fields.control}
          data={data}
          setData={setData}
          setIsValid={setIsValid}
        />
        {renderDropdowns()}
        {renderCheckBoxes()}
        {renderDatePickers()}
      </Fragment>
    )
  );
};

export default FormBasic;
