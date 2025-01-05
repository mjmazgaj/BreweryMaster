import React, { useState } from "react";
import { Form } from "react-bootstrap";

import { useFormControls } from "./helpers/useFormControls";

const FormControls = ({
  fields,
  data,
  setData,
  isReadOnly = false,
  setIsValid,
}) => {
  const [invalidFields, setInvalidFields] = useState({});

  const { handleInputChange } = useFormControls({
    setData,
    setIsValid,
    invalidFields,
    setInvalidFields,
  });

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
              onChange={
                isReadOnly
                  ? undefined
                  : (event) => handleInputChange(event, field)
              }
              disabled={isReadOnly}
              required={field.required}
              min={field.type === "number" ? field.min : null}
              max={field.type === "number" ? field.max : null}
              isInvalid={invalidFields[field.id]}
            />
            {field.feedback && invalidFields[field.id] && (
              <Form.Control.Feedback type="invalid">
                {field.feedback}
              </Form.Control.Feedback>
            )}
          </div>
        ))}
      </div>
    )
  );
};

export default FormControls;
