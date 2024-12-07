import React from 'react';
import { Form } from "react-bootstrap";

const Address = ({
  addressId,
  deliveryAddressId,
  setAddressId,
  setDeliveryAddressId,
}) => {
  
  return (
    <div className="form-address">
      <Form.Label>Address</Form.Label>
      <Form.Control
        id="addressId"
        type="text"
        placeholder="Enter Address Id"
        value={addressId}
        onChange={(e) => setAddressId(e.target.value)}
      />
      <Form.Label>Delivery Address</Form.Label>
      <Form.Control
        id="deliveryAddressId"
        type="text"
        placeholder="Enter Delivery Address Id"
        value={deliveryAddressId}
        onChange={(e) => setDeliveryAddressId(e.target.value)}
      />
    </div>
  );
};

export default Address;
