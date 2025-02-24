import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";

import { useCustomForm } from "./ModalComponents/helpers/useCustomForm";
import FormControls from "./FormControls";

import DropDownIndex from "./DropDownIndex";
import FormDatePicker from "./FormDatePicker";

const CustomForm = ({ data, setData, fields, formCustomizationObject }) => {
  const [isValid, setIsValid] = useState({});

  const {
    handleCheckBox,
    handleSelectChange,
    handleDateChange,
    handleFormSubmit,
  } = useCustomForm({
    setData,
    isValid,
    formCustomizationObject,
  });

  const renderDropdowns = () =>
    fields?.dropdown && (
      <div
        className={`${formCustomizationObject.classNamePrefix}_dropdown-container`}
      >
        <hr />
        {fields.dropdown.map((dropdownObject, index) => (
          <DropDownIndex
            key={`${index}_dropdown`}
            id={`${formCustomizationObject.classNamePrefix}_dropdown`}
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
      <div
        className={`${formCustomizationObject.classNamePrefix}_checkbox-container`}
      >
        <hr />
        {fields.checkBox.map((checkBoxObject, index) => (
          <Form.Check
            type="switch"
            key={`${index}_checkbox`}
            id={checkBoxObject.name}
            label={checkBoxObject.label}
            onChange={(e) =>
              handleCheckBox(checkBoxObject.id, e.target.checked)
            }
          />
        ))}
      </div>
    );

  const renderDatePickers = () =>
    fields?.datePicker && (
      <div
        className={`${formCustomizationObject.classNamePrefix}_datepicker-container`}
      >
        <hr />
        {fields.datePicker.map((datePickerObject, index) => (
          <FormDatePicker
            key={`datepicker-${index}`}
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
      <Form
        className={formCustomizationObject.classNamePrefix}
        onSubmit={(event) => handleFormSubmit(event, data)}
      >
        {formCustomizationObject?.title && (
          <h2>{formCustomizationObject?.title}</h2>
        )}
        <FormControls
          fields={fields.control}
          data={data}
          setData={setData}
          setIsValid={setIsValid}
        />
        {renderDropdowns()}
        {renderCheckBoxes()}
        {renderDatePickers()}
        <div
          className={`${formCustomizationObject.classNamePrefix}_buttons-container`}
        >
          {formCustomizationObject?.buttons &&
            formCustomizationObject.buttons.map((button, index) => (
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
        </div>
      </Form>
    )
  );
};

export default CustomForm;
