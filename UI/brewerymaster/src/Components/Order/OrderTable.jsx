import React from 'react';
import Table from 'react-bootstrap/Table';

const OrderTable = ({ data, handleEdit, handleDelete }) => {
  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>#</th>
          <th>Forename</th>
          <th>Surname</th>
          <th>CompanyName</th>
          <th>Nip</th>
          <th>AddressId</th>
          <th>DeliveryAddressId</th>
          <th>PhoneNumber</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        {data && data.length > 0 ? data.map((item, index) => (
          <tr key={index}>
            <td>{index + 1}</td>
            <td>{item.forename}</td>
            <td>{item.surname}</td>
            <td>{item.companyName}</td>
            <td>{item.nip}</td>
            <td>{item.addressId}</td>
            <td>{item.deliveryAddressId}</td>
            <td>{item.phoneNumber}</td>
            <td>{item.email}</td>
            <td colSpan={2}>
              <button className="btn btn-primary" onClick={() => handleEdit(item.id)}>
                Edit
              </button>
              &nbsp;
              <button className="btn btn-danger" onClick={() => handleDelete(item.id)}>
                Delete
              </button>
            </td>
          </tr>
        )) : <tr><td colSpan="5">Loading...</td></tr>}
      </tbody>
    </Table>
  );
};

export default OrderTable;
