import React from 'react';
import { Modal, Button, Container, Row, Col } from 'react-bootstrap';

const ClientModal = ({
  show,
  handleClose,
  editForename,
  setEditForename,
  editSurname,
  setEditSurname,
  editCompanyName,
  setEditCompanyName,
  editNip,
  setEditNip,
  editAddressId,
  setEditAddressId,
  editDeliveryAddressId,
  setEditDeliveryAddressId,
  editPhoneNumber,
  setEditPhoneNumber,
  editEmail,
  setEditEmail,
  handleUpdate
}) => {

  const inputs = [
    {
      id: 1,
      name: "Forename",
      value: editForename,
      setState: setEditForename,
    },
    {
      id: 2,
      name: "Surname",
      value: editSurname,
      setState: setEditSurname,
    },
    {
      id: 3,
      name: "CompanyName",
      value: editCompanyName,
      setState: setEditCompanyName,
    },
    {
      id: 4,
      name: "Address",
      value: editAddressId,
      setState: setEditAddressId,
    },
    {
      id: 5,
      name: "Delivery Address",
      value: editDeliveryAddressId,
      setState: setEditDeliveryAddressId,
    },
    {
      id: 6,
      name: "Phone Number",
      value: editPhoneNumber,
      setState: setEditPhoneNumber,
    },
    {
      id: 7,
      name: "Email",
      value: editEmail,
      setState: setEditEmail,
    },
    {
      id: 8,
      name: "nip",
      value: editNip,
      setState: setEditNip,
    }
  ]

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Modify Client</Modal.Title>
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

export default ClientModal;
