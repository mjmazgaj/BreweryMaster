import React from 'react';
import { Form } from "react-bootstrap";

const IndividualClientDetails = ({
  forename,
  surname,
  setForename,
  setSurname,
}) => {
  return (
    <div className="form-individual-client-details">
      <Form.Label>Surname</Form.Label>
      <Form.Control
        id="forename"
        type="text"
        placeholder="Enter Forename"
        value={forename}
        onChange={(e) => setForename(e.target.value)}
      />
      <Form.Label>Surname</Form.Label>
      <Form.Control
        id="surname"
        type="text"
        placeholder="Enter Surname"
        value={surname}
        onChange={(e) => setSurname(e.target.value)}
      />
    </div>
  );
};

export default IndividualClientDetails;
