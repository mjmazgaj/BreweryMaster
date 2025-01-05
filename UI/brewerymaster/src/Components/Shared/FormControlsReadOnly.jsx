import React from "react";
import { Form } from "react-bootstrap";

const FormControlsReadOnly = ({
  fields,
  data,
}) => {

  return (
    fields && (
      <div className="formControl_container">
        {fields.map((field) => (
          <div key={field.id} className="form-group">
            <Form.Label>{field.label}</Form.Label>
            <Form.Control
              id={field.id}
              type={field.type}
              placeholder={field.label}
              value={(data && data[field.id]) || ""}
              disabled={true}
            />
          </div>
        ))}
      </div>
    )
  );
};

export default FormControlsReadOnly;
