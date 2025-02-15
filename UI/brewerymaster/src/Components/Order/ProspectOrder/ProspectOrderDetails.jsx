import React, {Fragment, useState, useEffect} from "react";
import {  Form } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';

import { fetchData } from "../../Shared/api";

import DropDownIndex from "../../Shared/DropDownIndex";
import ProspectOrderCheckPrice from "./ProspectOrderCheckPrice";

const ProspectOrderDetails = ({prospectOrderData, setProspectOrderData}) => { 
  const handleInputChange = (key, e) => {
    const { value } = e.target;
    setProspectOrderData((prevData) => ({
      ...prevData,
      [key]: parseInt(value),
    }));
  };

  const [details, setDetails] = useState({});

  useEffect(() => {
    fetchData("ProspectOrder/Details", setDetails);
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
          onChange={(value) => handleInputChange("capacity", value)}
        />
        {details["beerTypes"] && (
          <DropDownIndex
            id={"beer-types"}
            data={details.beerTypes}
            selectedOption={prospectOrderData.selectedBeer}
            setSelectedOption={(value) =>
              handleInputChange("selectedBeer", value)
            }
            isReadOnly={false}
            label="Beer type"
          />
        )}
        {details["beerTypes"] && (
          <DropDownIndex
            id={"container-types"}
            data={details.containerTypes}
            selectedOption={prospectOrderData.selectedContainer}
            setSelectedOption={(value) =>
              handleInputChange("selectedContainer", value)
            }
            isReadOnly={false}
            label="Container type"
          />
        )}
      </div>
      <ProspectOrderCheckPrice prospectOrderData={prospectOrderData} />
    </Fragment>
  );
}

export default ProspectOrderDetails;