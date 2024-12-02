import React from 'react';
import { Row, Col, Button } from 'react-bootstrap';

const OrderForm = ({
  forename,
  surname,
  companyName,
  nip,
  addressId,
  deliveryAddressId,
  phoneNumber,
  email,
  setForename,
  setSurname,
  setCompanyName,
  setNip,
  setAddressId,
  setDeliveryAddressId,
  setPhoneNumber,
  setEmail,
  handleSave,
}) => {
  return (
    <form>
      <Row>
        <Col key="forename">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Forename"
            value={forename}
            onChange={(e) => setForename(e.target.value)}
          />
        </Col>
        <Col key="surname">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Surname"
            value={surname}
            onChange={(e) => setSurname(e.target.value)}
          />
        </Col>
        <Col key="companyName">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Company Name"
            value={companyName}
            onChange={(e) => setCompanyName(e.target.value)}
          />
        </Col>
        <Col key="nip">
          <input
            type="text"
            className="form-control"
            placeholder="Enter nip"
            value={nip}
            onChange={(e) => setNip(e.target.value)}
          />
        </Col>
        <Col key="addressId">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Address Id"
            value={addressId}
            onChange={(e) => setAddressId(e.target.value)}
          />
        </Col>
        <Col key="deliveryAddressId">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Delivery Address Id"
            value={deliveryAddressId}
            onChange={(e) => setDeliveryAddressId(e.target.value)}
          />
        </Col>
        <Col key="phoneNumber">
          <input
            type="text"
            className="form-control"
            placeholder="Enter PhoneNumber"
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </Col>
        <Col key="email">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </Col>
        <Col key="submit">
          <Button className="btn btn-primary" onClick={handleSave}>
            Submit
          </Button>
        </Col>
      </Row>
    </form>
  );
};

export default OrderForm;
