import { React, useState, useEffect } from "react";
import { Button, Form } from "react-bootstrap";
import { fetchDetails } from "./api";
import ProspectOrderDropDown from "./ProspectOrderDropDown";
import 'bootstrap/dist/css/bootstrap.min.css'
import { toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import './order.css';
import { addData, checkPrice } from './api';

const ProspectOrderForm = () => {  
  const [forename, setForename] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [email, setEmail] = useState("");
  const [selectedBeer, setSelectedBeer] = useState("");
  const [selectedContainer, setSelectedContainer] = useState("");
  const [capacity, setCapacity] = useState("");

  const [details, setDetails] = useState([]);
  const [estimatedPrice, setEstimatedPrice] = useState("");

  const handleSave = () => {
    const newData = {
      forename,
      phoneNumber,
      email,
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
    setPhoneNumber("");
    setEmail("");
  };

  const handleCheckPrice = () => {
    checkPrice(selectedBeer, selectedContainer, capacity)
      .then((result) => setEstimatedPrice(result))
      .catch((error) => console.log(error));
  };

  useEffect(() => {
    getDetails();
  }, []);

  const getDetails = () => {
    fetchDetails()
      .then((result) => setDetails(result))
      .catch((error) => console.log(error));
  };

  return (
    <form>
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
        <Form.Label>PhoneNumber</Form.Label>
        <Form.Control
          id="phoneNumber"
          type="text"
          placeholder="Enter PhoneNumber"
          onChange={(e) => setPhoneNumber(e.target.value)}
        />
        <Form.Label>Email</Form.Label>
        <Form.Control
          id="email"
          type="text"
          placeholder="Enter Email"
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>
      <Button id="submit" className="btn btn-secondary" onClick={handleSave}>
        Submit
      </Button>
    </form>
  );
};

export default ProspectOrderForm;
