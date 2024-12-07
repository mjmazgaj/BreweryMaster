import { React, useState, useEffect } from "react";
import { Button, Form } from "react-bootstrap";
import { fetchDetails } from "../api";
import ProspectOrderDropDown from "./ProspectOrderDropDown";
import 'bootstrap/dist/css/bootstrap.min.css'
import { toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';
import { addData, checkPrice } from '../api';

import Contact from '../../Shared/Contact'
import Protected from "../../Shared/Protected";

const ProspectOrderForm = () => {  

  
  const [contactData, setContactData] = useState({
    phoneNumber: "",
    email: "",
  });

  const [forename, setForename] = useState("");
  const [selectedBeer, setSelectedBeer] = useState("");
  const [selectedContainer, setSelectedContainer] = useState("");
  const [capacity, setCapacity] = useState("");

  const [details, setDetails] = useState([]);
  const [estimatedPrice, setEstimatedPrice] = useState("");

  const handleSave = () => {
    const newData = {
      forename,
      phoneNumber : contactData.phoneNumber,
      email : contactData.email,
      selectedBeer,
      selectedContainer,
      capacity,
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
    checkPrice(selectedBeer, selectedContainer, capacity);
  };

  useEffect(() => {
    fetchDetails(setDetails);
  }, []);

  return (
    <form className="prospectorder-form">
      <div className="order-details">
        <h3>Order</h3>
        <p>Please enter your order details</p>

        <Form.Label>Capacity</Form.Label>
        <Form.Control
          id="capacity"
          type="number"
          placeholder="Enter capacity"
          onChange={(e) => setCapacity(e.target.value)}
        />
        <Form.Label>Beer type</Form.Label>
        <ProspectOrderDropDown
          id="beer-types"
          data={details["beerTypes"]}
          selectedOption={selectedBeer}
          setSelectedOption={setSelectedBeer}
        />
        <Form.Label>Container type</Form.Label>
        <ProspectOrderDropDown
          id="container-types"
          data={details["containerTypes"]}
          selectedOption={selectedContainer}
          setSelectedOption={setSelectedContainer}
        />
      </div>
      <div className="checkprice_container">
        <Button
          id="checkPrice"
          className="btn btn-secondary"
          onClick={handleCheckPrice}
        >
          CheckPrice
        </Button>
        <div>
          <Form.Label className="form-label_checkPrice">
            Estimated Price:
          </Form.Label>
          <Form.Control
            id="checkPrice_result"
            readOnly={true}
            placeholder="Check Price"
            type="number"
            value={estimatedPrice}
          />
        </div>
      </div>

      <div className="contact-details">
        <h3>Contact</h3>
        <p>Please enter your contact details</p>
        <Form.Label>Forename</Form.Label>
        <Form.Control
          id="forename"
          type="text"
          placeholder="Enter Forename"
          onChange={(e) => setForename(e.target.value)}
        />
        <Contact contactData={contactData} setContactData={setContactData}/>
      </div>
      <Button id="submit" className="btn btn-secondary" onClick={handleSave}>
        Submit
      </Button>
    </form>
  );
};

export default ProspectOrderForm;
