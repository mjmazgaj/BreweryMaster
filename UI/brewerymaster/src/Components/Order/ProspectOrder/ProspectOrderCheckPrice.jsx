import React, {Fragment, useState} from "react";
import { Button, Form } from "react-bootstrap";

import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';

import { fetchData } from "../../Shared/api";
import { createPath } from "../../Shared/helpers/useObjectHelper";

const ProspectOrderCheckPrice = ({ prospectOrderData }) => {  
  const [estimatedPrice, setEstimatedPrice] = useState("");

  const handleCheckPrice = () => {

    let query = {
      "BeerType" : prospectOrderData.selectedBeer,
      "ContainerType" : prospectOrderData.selectedContainer,
      "Capacity" : prospectOrderData.capacity,
    };

    const path = createPath("ProspectOrder/Price", query);

    console.log(path);
    fetchData(path, setEstimatedPrice);
  };

  return (
    <Fragment>
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
    </Fragment>
  );
};

export default ProspectOrderCheckPrice;