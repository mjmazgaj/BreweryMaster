import React, {Fragment, useState, useEffect} from "react";
import {  Form } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';

import { fetchDetails } from "../api";

import DropDown from "../../Shared/DropDown";
import ProspectOrderCheckPrice from "./ProspectOrderCheckPrice";

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
        <p>Please enter your order details</p>

        <Form.Label>Capacity</Form.Label>
        <Form.Control
          id="capacity"
          type="number"
          placeholder="Enter capacity"
          onChange={(e) => handleInputChange("capacity", e.target.value)}
        />
        <Form.Label>Beer type</Form.Label>
        <DropDown
          id="beer-types"
          data={details["beerTypes"] || []}
          selectedOption={prospectOrderData.selectedBeer}
          setSelectedOption={(value) =>
            handleInputChange("selectedBeer", value)
          }
        />
        <Form.Label>Container type</Form.Label>
        <DropDown
          id="container-types"
          data={details["containerTypes"] || []}
          selectedOption={prospectOrderData.selectedContainer}
          setSelectedOption={(value) =>
            handleInputChange("selectedContainer", value)
          }
        />
      </div>
      <ProspectOrderCheckPrice prospectOrderData={prospectOrderData} />
    </Fragment>
  );
}

export default ProspectOrderDetails;