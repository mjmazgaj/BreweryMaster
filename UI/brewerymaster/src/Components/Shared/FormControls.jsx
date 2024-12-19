import React from "react";
import { Form } from "react-bootstrap";

const FormControls = ({ fields, data, setData }) => {

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  return (
    <div className="formControl_container">
      {fields.map((field) => (
        <div key={field.id} className="form-group">
          <Form.Label>{field.label}</Form.Label>
          <Form.Control
            id={field.id}
            type={field.type}
            placeholder={field.label}
            value={data && data[field.id] || ""}
            onChange={handleInputChange}
            min={field.type === "number" ? field.min : null}
            max={field.type === "number" ? field.max : null}
          />
        </div>
      ))}
    </div>
  );
};

export default FormControls;
