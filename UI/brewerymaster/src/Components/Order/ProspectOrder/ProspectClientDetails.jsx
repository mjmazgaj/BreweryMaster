import React, {Fragment, useState, useEffect} from "react";
import {  Form } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';

import Contact from '../../Shared/Contact'

const ProspectClientDetails = ({contactData, setContactData}) => { 
  const handleInputChange = (key, value) => {
    setContactData((prevData) => ({
      ...prevData,
      [key]: value,
    }));
  };

  return (
    <Fragment>
    <div className="prospectorder-contact-details">
      <p>Please enter your contact details</p>
      <Form.Label>Forename</Form.Label>
      <Form.Control
        id="forename"
        type="text"
        placeholder="Enter Forename"
        onChange={handleInputChange}
      />
      <Contact contactData={contactData} setContactData={setContactData} />
    </div>
    </Fragment>
  );
}

export default ProspectClientDetails;