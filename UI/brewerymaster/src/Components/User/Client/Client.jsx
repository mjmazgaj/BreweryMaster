import React, {useState, useEffect, Fragment} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { fetchData, fetchDataById, addData, updateData, deleteData } from './api';

import ClientModal from './ClientModal';
import ClientTable from './ClientTable';
import ClientForm from './ClientForm';

const Address = () => { 

const [show, setShow] = useState(false);

const handleClose = () => setShow(false);

const[forename, setForename] = useState('');
const[surname, setSurname] = useState('');
const[companyName, setCompanyName] = useState('');
const[nip, setNip] = useState('');
const[addressId, setAddressId] = useState('');
const[deliveryAddressId, setDeliveryAddressId] = useState('');
const[phoneNumber, setPhoneNumber] = useState('');
const[email, setEmail] = useState('');

const[editId, setEditId] = useState('');
const[editForename, setEditForename] = useState('');
const[editSurname, setEditSurname] = useState('');
const[editCompanyName, setEditCompanyName] = useState('');
const[editNip, setEditNip] = useState('');
const[editAddressId, setEditAddressId] = useState('');
const[editDeliveryAddressId, setEditDeliveryAddressId] = useState('');
const[editPhoneNumber, setEditPhoneNumber] = useState('');
const[editEmail, setEditEmail] = useState('');

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
      setEditForename(result.forename);
      setEditSurname(result.surname);
      setEditCompanyName(result.companyName);
      setEditNip(result.nip);
      setEditAddressId(result.addressId);
      setEditDeliveryAddressId(result.deliveryAddressId);
      setEditPhoneNumber(result.phoneNumber);
      setEditEmail(result.email);     
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
    forename: editForename,
    surname: editSurname,
    companyName: editCompanyName,
    nip: editNip,
    addressId: editAddressId,
    deliveryAddressId: editDeliveryAddressId,
    phoneNumber: editPhoneNumber,
    email: editEmail
  };

  updateData(editId, updatedData)
    .then(() => {
      console.log(updatedData);
      setShow(false);
      getData();
      clear();
      toast.success('Client has been updated');
    })
    .catch((error) => console.log(error));
};

const handleSave = () => {
  const newData = {
    forename,
    surname,
    companyName,
    nip,
    addressId,
    deliveryAddressId,
    phoneNumber,
    email
  };

  addData(newData)
    .then(() => {
      getData();
      clear();
      toast.success('Client has been added');
    })
    .catch((error) => console.log(error));
};

const clear = () => {
  setForename('');
  setSurname('');
  setCompanyName('');
  setNip('');
  setAddressId('');
  setDeliveryAddressId('');
  setPhoneNumber('');
  setEmail('');
};

    return (
      <Fragment>
        <ToastContainer />
        <ClientForm
          forename={forename}
          surname={surname}
          companyName={companyName}
          nip={nip}
          addressId={addressId}
          deliveryAddressId={deliveryAddressId}
          phoneNumber={phoneNumber}
          email={email}
          setForename={setForename}
          setSurname={setSurname}
          setCompanyName={setCompanyName}
          setNip={setNip}
          setAddressId={setAddressId}
          setDeliveryAddressId={setDeliveryAddressId}
          setPhoneNumber={setPhoneNumber}
          setEmail={setEmail}
          handleSave={handleSave}
        />
        <ClientTable
          data={data}
          handleEdit={handleEdit}
          handleDelete={handleDelete}
        />
        <ClientModal
          show={show}
          handleClose={handleClose}
          editForename={editForename}
          setEditForename={setEditForename}
          editSurname={editSurname}
          setEditSurname={setEditSurname}
          editCompanyName={editCompanyName}
          setEditCompanyName={setEditCompanyName}
          editNip={editNip}
          setEditNip={setEditNip}
          editAddressId={editAddressId}
          setEditAddressId={setEditAddressId}
          editDeliveryAddressId={editDeliveryAddressId}
          setEditDeliveryAddressId={setEditDeliveryAddressId}
          editPhoneNumber={editPhoneNumber}
          setEditPhoneNumber={setEditPhoneNumber}
          editEmail={editEmail}
          setEditEmail={setEditEmail}
          handleUpdate={handleUpdate}
        />
      </Fragment>
    );
}

export default Address;