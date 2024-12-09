import { React, useState, useEffect } from "react";
import { Button, Form } from "react-bootstrap";
import ProspectOrderDetails from "./ProspectOrderDetails";
import 'bootstrap/dist/css/bootstrap.min.css'
import { toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';
import { addData, checkPrice } from '../api';

import Contact from '../../Shared/Contact'

const ProspectOrderForm = () => {  
  
  const [contactData, setContactData] = useState({
    phoneNumber: "",
    email: "",
  });

  const [prospectOrderData, setProspectOrderData] = useState({
    selectedContainer: "",
    selectedBeer: "",
    capacity: "",
  });

  const [forename, setForename] = useState("");

  const [estimatedPrice, setEstimatedPrice] = useState("");
  
  const handleSave = () => {
    const newData = {
      forename,
      phoneNumber : contactData.phoneNumber,
      email : contactData.email,
      selectedBeer : prospectOrderData.selectedBeer,
      selectedContainer : prospectOrderData.selectedContainer,
      capacity : prospectOrderData.capacity,
    };

    addData(newData)
      .then(() => {
        clear();
        toast.success("Order has been registered");
      })
      .catch((error) => console.log(error));
  };

  const clear = () => {
    setForename("");
    setContactData({
      phoneNumber: "",
      email: "",
    });
  };

  const handleCheckPrice = () => {
    checkPrice(prospectOrderData.selectedBeer, prospectOrderData.selectedContainer, prospectOrderData.capacity)
    .then((result) => setEstimatedPrice(result));
  };

  return (
    <form className="prospectorder-form">
      <ProspectOrderDetails
        setProspectOrderData={setProspectOrderData}
        prospectOrderData={prospectOrderData}
      />
      <div className="prospectorder-checkprice_container">
        <Button
          id="checkPrice"
          className="btn btn-secondary"
          onClick={handleCheckPrice}
        >
          CheckPrice
        </Button>
        <div>
          <Form.Label className="prospectorder-checkPrice_label">
            Estimated Price:
          </Form.Label>
          <Form.Control
            className="prospectorder-checkPrice_result"
            readOnly={true}
            placeholder="Check Price"
            type="number"
            value={estimatedPrice}
          />
        </div>
      </div>

      <div className="prospectorder-contact-details">
        <h3>Contact</h3>
        <p>Please enter your contact details</p>
        <Form.Label>Forename</Form.Label>
        <Form.Control
          id="forename"
          type="text"
          placeholder="Enter Forename"
          onChange={(e) => setForename(e.target.value)}
        />
        <Contact contactData={contactData} setContactData={setContactData} />
      </div>
      <Button id="submit" className="btn btn-secondary" onClick={handleSave}>
        Submit
      </Button>
    </form>
  );
};

export default ProspectOrderForm;
