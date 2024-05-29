import React from 'react';
import Table from 'react-bootstrap/Table';

const AddressTable = ({ data, handleEdit, handleDelete }) => {
  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>#</th>
          <th>City</th>
          <th>Street</th>
          <th>HouseNumber</th>
          <th>ApartamentNumber</th>
          <th>PostalCode</th>
          <th>Country</th>
          <th>Region</th>
          <th>Commune</th>
        </tr>
      </thead>
      <tbody>
        {data.length > 0 ? data.map((item, index) => (
          <tr key={index}>
            <td>{index + 1}</td>
            <td>{item.city}</td>
            <td>{item.street}</td>
            <td>{item.houseNumber}</td>
            <td>{item.apartamentNumber}</td>
            <td>{item.postalCode}</td>
            <td>{item.country}</td>
            <td>{item.region}</td>
            <td>{item.commune}</td>
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

export default AddressTable;
