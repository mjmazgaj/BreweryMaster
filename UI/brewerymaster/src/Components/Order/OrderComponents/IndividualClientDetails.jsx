import React from 'react';
import { Form } from "react-bootstrap";

const IndividualClientDetails = ({
  individualClientDetailsData,
  setIndividualClientDetailsData
}) => {

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setIndividualClientDetailsData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  return (
    <div className="form-individual-client-details">
      <Form.Label>Surname</Form.Label>
      <Form.Control
        id="forename"
        type="text"
        placeholder="Enter Forename"
        value={individualClientDetailsData.forename}
        onChange={handleInputChange}
      />
      <Form.Label>Surname</Form.Label>
      <Form.Control
        id="surname"
        type="text"
        placeholder="Enter Surname"
        value={individualClientDetailsData.surname}
        onChange={handleInputChange}
      />
    </div>
  );
};

export default IndividualClientDetails;
