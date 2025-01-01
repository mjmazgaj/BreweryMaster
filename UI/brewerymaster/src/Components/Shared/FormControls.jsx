import React from "react";
import { Form } from "react-bootstrap";

const FormControls = ({ fields, data, setData, isReadOnly = false }) => {
  const handleInputChange = (e) => {
    const { id, value, type } = e.target;
    setData((prevData) => ({
      ...prevData,
      [id]: type === "number" ? parseFloat(value) : value,
    }));
  };

  return fields ? (
    <div className="formControl_container">
      {fields.map((field) => (
        <div key={field.id} className="form-group">
          <Form.Label>{field.label}</Form.Label>
          <Form.Control
            id={field.id}
            type={field.type}
            placeholder={field.label}
            value={(data && data[field.id]) || ""}
            onChange={isReadOnly ? null : handleInputChange}
            readOnly={isReadOnly}
            min={field.type === "number" ? field.min : null}
            max={field.type === "number" ? field.max : null}
          />
        </div>
      ))}
    </div>
  ) : (
    <></>
  );
};

export default FormControls;
