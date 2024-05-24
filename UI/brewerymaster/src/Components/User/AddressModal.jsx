import React from 'react';
import { Modal, Button, Container, Row, Col } from 'react-bootstrap';

const AddressModal = ({
  show,
  handleClose,
  editApartamentNumber,
  setEditApartamentNumber,
  editCity,
  setEditCity,
  editCommune,
  setEditCommune,
  editCountry,
  setEditCountry,
  editHouseNumber,
  setEditHouseNumber,
  editPostalCode,
  setEditPostalCode,
  editRegion,
  setEditRegion,
  editStreet,
  setEditStreet,
  handleUpdate
}) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Modify Address</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Container>
          <Row>
            <Col>
              <input
                type="text"
                className="form-control"
                placeholder="Apartment Number"
                value={editApartamentNumber}
                onChange={(e) => setEditApartamentNumber(e.target.value)}
              />
            </Col>
            <Col>
              <input
                type="text"
                className="form-control"
                placeholder="City"
                value={editCity}
                onChange={(e) => setEditCity(e.target.value)}
              />
            </Col>
          </Row>
          <Row>
            <Col>
              <input
                type="text"
                className="form-control"
                placeholder="Commune"
                value={editCommune}
                onChange={(e) => setEditCommune(e.target.value)}
              />
            </Col>
            <Col>
              <input
                type="text"
                className="form-control"
                placeholder="Country"
                value={editCountry}
                onChange={(e) => setEditCountry(e.target.value)}
              />
            </Col>
          </Row>
          <Row>
            <Col>
              <input
                type="text"
                className="form-control"
                placeholder="House Number"
                value={editHouseNumber}
                onChange={(e) => setEditHouseNumber(e.target.value)}
              />
            </Col>
            <Col>
              <input
                type="text"
                className="form-control"
                placeholder="Postal Code"
                value={editPostalCode}
                onChange={(e) => setEditPostalCode(e.target.value)}
              />
            </Col>
          </Row>
          <Row>
            <Col>
              <input
                type="text"
                className="form-control"
                placeholder="Region"
                value={editRegion}
                onChange={(e) => setEditRegion(e.target.value)}
              />
            </Col>
            <Col>
              <input
                type="text"
                className="form-control"
                placeholder="Street"
                value={editStreet}
                onChange={(e) => setEditStreet(e.target.value)}
              />
            </Col>
          </Row>
        </Container>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Close
        </Button>
        <Button variant="primary" onClick={handleUpdate}>
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default AddressModal;
