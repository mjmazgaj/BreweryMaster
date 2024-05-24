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

  const inputs = [
    {
      id: 1,
      name: "Apartment Number",
      value: editApartamentNumber,
      setState: setEditApartamentNumber,
    },
    {
      id: 2,
      name: "City",
      value: editCity,
      setState: setEditCity,
    },
    {
      id: 3,
      name: "Commune",
      value: editCommune,
      setState: setEditCommune,
    },
    {
      id: 4,
      name: "House Number",
      value: editHouseNumber,
      setState: setEditHouseNumber,
    },
    {
      id: 5,
      name: "Postal Code",
      value: editPostalCode,
      setState: setEditPostalCode,
    },
    {
      id: 6,
      name: "Region",
      value: editRegion,
      setState: setEditRegion,
    },
    {
      id: 7,
      name: "Street",
      value: editStreet,
      setState: setEditStreet,
    },
    {
      id: 8,
      name: "Country",
      value: editCountry,
      setState: setEditCountry,
    }
  ]

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Modify Address</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Container>
          {
            inputs.map((input) => (
              <Col>
                <label>{input.name}</label>
                <input
                  key={input.id}
                  type="text"
                  className="form-control"
                  placeholder={input.name}
                  value={input.value}
                  onChange={(e) => input.setState(e.target.value)}
                />
              </Col>
            ))
          }
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
