import React from 'react';
import { Form } from "react-bootstrap";

const Contact = ({ contactData, setContactData }) => {

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setContactData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  return (
    <div className="form-contact">
      <Form.Label>PhoneNumber</Form.Label>
      <Form.Control
        id="phoneNumber"
        type="text"
        placeholder="Enter PhoneNumber"
        value={contactData.phoneNumber}
        onChange={handleInputChange}
      />
      <Form.Label>Email</Form.Label>
      <Form.Control
        id="email"
        type="text"
        placeholder="Enter Email"
        value={contactData.email}
        onChange={handleInputChange}
      />
    </div>
  );
};

export default Contact;
