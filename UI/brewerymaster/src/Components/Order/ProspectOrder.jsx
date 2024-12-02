import React, {useState, useEffect, Fragment} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import './order.css';
import { addData, checkPrice } from './api';

import ProspectOrderForm from "./ProspectOrderForm";

const ProspectOrder = () => { 

const[forename, setForename] = useState('');
const[phoneNumber, setPhoneNumber] = useState('');
const[email, setEmail] = useState('');
const [selectedBeer, setSelectedBeer] = useState("");
const [selectedContainer, setSelectedContainer] = useState("");
const [capacity, setCapacity] = useState("");
const [estimatedPrice, setEstimatedPrice] = useState("");

const handleCheckPrice = () => {
  checkPrice(selectedBeer, selectedContainer, capacity)
  .then((result) => setEstimatedPrice(result))
  .catch((error) => console.log(error));
};


const handleSave = () => {
  const newData = {
    forename,
    phoneNumber,
    email,
    selectedBeer,
    selectedContainer,
    capacity
  };

  addData(newData)
    .then(() => {
      clear();
      toast.success('Client has been added');
    })
    .catch((error) => console.log(error));
};

const clear = () => {
  setForename('');
  setPhoneNumber('');
  setEmail('');
};

    return (
      <Fragment>
        <div className="background-details">
          <div className="left-image">
            <img src="./glass.png" alt="" />
          </div>
          <div className="right-image">
            <img src="./bottle.png" alt="" />
          </div>
        </div>
        <ToastContainer />
        <div className="form-container">
          <ProspectOrderForm
            selectedBeer={selectedBeer}
            selectedContainer={selectedContainer}
            setForename={setForename}
            setPhoneNumber={setPhoneNumber}
            setEmail={setEmail}
            setSelectedBeer={setSelectedBeer}
            setSelectedContainer={setSelectedContainer}
            setCapacity={setCapacity}
            handleSave={handleSave}
            handleCheckPrice={handleCheckPrice}
          />
        </div>
        {estimatedPrice ? (
          <h1>Twoja wycena: {estimatedPrice}</h1>
        ) : (
          <h1>Wyceń swój produkt</h1>
        )}
      </Fragment>
    );
}

export default ProspectOrder;