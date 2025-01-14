import React from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import { Form } from 'react-bootstrap';

const FormDatePicker = ({selectedDate, setSelectedDate}) => {

  return (
      <Form.Group controlId="formDatePicker">
        <Form.Label>Wybierz datę:</Form.Label>
        <DatePicker
          selected={selectedDate}
          onChange={(date) => setSelectedDate(date)}
          className="form-control"
          dateFormat="dd/MM/yyyy"
          placeholderText="Kliknij, aby wybrać datę"
        />
      </Form.Group>
  );
};

export default FormDatePicker;
