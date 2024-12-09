import React, {Fragment, useState, useEffect} from "react";
import {  Form } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';

import { fetchDetails } from "../api";

import ProspectOrderDropDown from "./ProspectOrderDropDown";

const ProspectOrderDetails = ({prospectOrderData, setProspectOrderData}) => { 
  const handleInputChange = (key, value) => {
    setProspectOrderData((prevData) => ({
      ...prevData,
      [key]: value,
    }));
  };

  const [details, setDetails] = useState([]);

  useEffect(() => {
    fetchDetails(setDetails);
  }, []);

  return (
      <Fragment>
          
      <div className="prospectorder-details">
        <h3>Order</h3>
        <p>Please enter your order details</p>

        <Form.Label>Capacity</Form.Label>
        <Form.Control
          id="capacity"
          type="number"
          placeholder="Enter capacity"
          onChange={(e) => handleInputChange("capacity", e.target.value)}
        />
        <Form.Label>Beer type</Form.Label>
        <ProspectOrderDropDown
          id="beer-types"
          data={details["beerTypes"] || []}
          selectedOption={prospectOrderData.selectedBeer}
          setSelectedOption={(value) => handleInputChange("selectedBeer", value)}
        />
        <ProspectOrderDropDown
          id="container-types"
          data={details["containerTypes"] || []}
          selectedOption={prospectOrderData.selectedContainer}
          setSelectedOption={(value) => handleInputChange("selectedContainer", value)}
        />
      </div>
      </Fragment>
    );
}

export default ProspectOrderDetails;