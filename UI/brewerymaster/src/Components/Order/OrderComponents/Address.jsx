import React from 'react';
import { Form } from "react-bootstrap";

const Address = ({
  addressData,
  setAddressData
}) => {

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setAddressData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };
  
  return (
    <div className="form-address">
      <Form.Label>Address</Form.Label>
      <Form.Control
        id="addressId"
        type="text"
        placeholder="Enter Address Id"
        value={addressData.addressId}
        onChange={handleInputChange}
      />
      <Form.Label>Delivery Address</Form.Label>
      <Form.Control
        id="deliveryAddressId"
        type="text"
        placeholder="Enter Delivery Address Id"
        value={addressData.deliveryAddressId}
        onChange={handleInputChange}
      />
    </div>
  );
};

export default Address;
