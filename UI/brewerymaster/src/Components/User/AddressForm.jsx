import React from 'react';
import { Row, Col, Button } from 'react-bootstrap';

const AddressForm = ({
  city,
  street,
  houseNumber,
  apartamentNumber,
  postalCode,
  country,
  region,
  commune,
  setCity,
  setStreet,
  setHouseNumber,
  setApartamentNumber,
  setPostalCode,
  setCountry,
  setRegion,
  setCommune,
  handleSave,
}) => {
  return (
    <form>
      <Row>
        <Col key="city">
          <input
            type="text"
            className="form-control"
            placeholder="Enter City"
            value={city}
            onChange={(e) => setCity(e.target.value)}
          />
        </Col>
        <Col key="street">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Street"
            value={street}
            onChange={(e) => setStreet(e.target.value)}
          />
        </Col>
        <Col key="houseNumber">
          <input
            type="text"
            className="form-control"
            placeholder="Enter House Number"
            value={houseNumber}
            onChange={(e) => setHouseNumber(e.target.value)}
          />
        </Col>
        <Col key="apartamentNumber">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Apartment Number"
            value={apartamentNumber}
            onChange={(e) => setApartamentNumber(e.target.value)}
          />
        </Col>
        <Col key="postalCode">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Postal Code"
            value={postalCode}
            onChange={(e) => setPostalCode(e.target.value)}
          />
        </Col>
        <Col key="country">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Country"
            value={country}
            onChange={(e) => setCountry(e.target.value)}
          />
        </Col>
        <Col key="region">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Region"
            value={region}
            onChange={(e) => setRegion(e.target.value)}
          />
        </Col>
        <Col key="commune">
          <input
            type="text"
            className="form-control"
            placeholder="Enter Commune"
            value={commune}
            onChange={(e) => setCommune(e.target.value)}
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

export default AddressForm;
