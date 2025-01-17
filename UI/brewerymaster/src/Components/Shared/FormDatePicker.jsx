import React from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import { Form } from 'react-bootstrap';

import "./shared.css"

const FormDatePicker = ({ id, label, selectedDate, setSelectedDate }) => {
  return (
    <Form.Group controlId={id} className='datepicker_container'>
      <Form.Label>{label}</Form.Label>
      <DatePicker
        selected={selectedDate}
        onChange={(date) => setSelectedDate(date)}
        className="form-control"
        dateFormat="dd/MM/yyyy"
        placeholderText="Click to add date"
      />
    </Form.Group>
  );
};

export default FormDatePicker;
