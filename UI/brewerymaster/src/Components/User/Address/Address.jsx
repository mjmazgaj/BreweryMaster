import React, {useState, useEffect, Fragment} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { fetchData, fetchDataById, addData, updateData, deleteData } from './api';

import AddressModal from './AddressModal';
import AddressTable from './AddressTable';
import AddressForm from './AddressForm';

const Address = () => { 

const [show, setShow] = useState(false);

const handleClose = () => setShow(false);

const[apartamentNumber, setApartamentNumber] = useState('');
const[city, setCity] = useState('');
const[commune, setCommune] = useState('');
const[country, setCountry] = useState('');
const[houseNumber, setHouseNumber] = useState('');
const[postalCode, setPostalCode] = useState('');
const[region, setRegion] = useState('');
const[street, setStreet] = useState('');

const[editId, setEditId] = useState('');
const[editApartamentNumber, setEditApartamentNumber] = useState('');
const[editCity, setEditCity] = useState('');
const[editCommune, setEditCommune] = useState('');
const[editCountry, setEditCountry] = useState('');
const[editHouseNumber, setEditHouseNumber] = useState('');
const[editPostalCode, setEditPostalCode] = useState('');
const[editRegion, setEditRegion] = useState('');
const[editStreet, setEditStreet] = useState('');

const [data, setData]  = useState([]);

useEffect(()=>{
    getData();
},[])


const getData = () => {
  fetchData()
  .then((result) => setData(result))
  .catch((error) => console.log(error));
};

const handleEdit = (id) => {
  setShow(true);
  fetchDataById(id)
    .then((result) => {
      setEditApartamentNumber(result.apartamentNumber);
      setEditCity(result.city);
      setEditCommune(result.commune);
      setEditCountry(result.country);
      setEditHouseNumber(result.houseNumber);
      setEditPostalCode(result.postalCode);
      setEditRegion(result.region);
      setEditStreet(result.street);     
      setEditId(id); 
    })
    .catch((error) => console.log(error));
};

const handleDelete = (id) => {
  if (window.confirm("Are you sure to delete this Address") === true) {
    deleteData(id)
      .then((result) => {
        if (result) {
          toast.success('Address has been deleted');
          getData();
        }
      })
      .catch((error) => toast.error(error));
  }
};


const handleUpdate = () => {
  const updatedData = {
    id: editId,
    city: editCity,
    street: editStreet,
    houseNumber: editHouseNumber,
    apartamentNumber: editApartamentNumber,
    postalCode: editPostalCode,
    country: editCountry,
    region: editRegion,
    commune: editCommune
  };

  updateData(editId, updatedData)
    .then(() => {
      console.log(updatedData);
      setShow(false);
      getData();
      clear();
      toast.success('Employee has been updated');
    })
    .catch((error) => console.log(error));
};

const handleSave = () => {
  const newData = {
    city,
    street,
    houseNumber,
    apartamentNumber,
    postalCode,
    country,
    region,
    commune
  };

  addData(newData)
    .then(() => {
      getData();
      clear();
      toast.success('Employee has been added');
    })
    .catch((error) => console.log(error));
};

const clear = () => {
  setApartamentNumber('');
  setCity('');
  setCommune('');
  setCountry('');
  setHouseNumber('');
  setPostalCode('');
  setRegion('');
  setStreet('');
};

    return (
      <Fragment>
        <ToastContainer />
        <AddressForm
          city={city}
          street={street}
          houseNumber={houseNumber}
          apartamentNumber={apartamentNumber}
          postalCode={postalCode}
          country={country}
          region={region}
          commune={commune}
          setCity={setCity}
          setStreet={setStreet}
          setHouseNumber={setHouseNumber}
          setApartamentNumber={setApartamentNumber}
          setPostalCode={setPostalCode}
          setCountry={setCountry}
          setRegion={setRegion}
          setCommune={setCommune}
          handleSave={handleSave}
        />
        <AddressTable
          data={data}
          handleEdit={handleEdit}
          handleDelete={handleDelete}
        />
        <AddressModal
          show={show}
          handleClose={handleClose}
          editApartamentNumber={editApartamentNumber}
          setEditApartamentNumber={setEditApartamentNumber}
          editCity={editCity}
          setEditCity={setEditCity}
          editCommune={editCommune}
          setEditCommune={setEditCommune}
          editCountry={editCountry}
          setEditCountry={setEditCountry}
          editHouseNumber={editHouseNumber}
          setEditHouseNumber={setEditHouseNumber}
          editPostalCode={editPostalCode}
          setEditPostalCode={setEditPostalCode}
          editRegion={editRegion}
          setEditRegion={setEditRegion}
          editStreet={editStreet}
          setEditStreet={setEditStreet}
          handleUpdate={handleUpdate}
        />
      </Fragment>
    );
}

export default Address;