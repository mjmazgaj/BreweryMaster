import React, {useState} from "react";
import { Row, Col, Button } from "react-bootstrap";
import { toast } from "react-toastify";
import { addData } from '../api';

import Address from './Address'
import CompanyClientDetails from './CompanyClientDetails'
import IndividualClientDetails from './IndividualClientDetails'
import Contact from './../../Shared/Contact'

const OrderForm = ({currentStep, setCurrentStep}) => {  

  const [contactData, setContactData] = useState({
    phoneNumber: "",
    email: "",
  });

  const [companyClientDetailsData, setCompanyClientDetailsData] = useState({
    companyName: "",
    nip: "",
  });

  const[forename, setForename] = useState('');
  const[surname, setSurname] = useState('');
  const[addressId, setAddressId] = useState('');
  const[deliveryAddressId, setDeliveryAddressId] = useState('');

  const handleSave = () => {
    const newData = {
      forename,
      surname,
      companyName : companyClientDetailsData.forename,
      nip : companyClientDetailsData.surname,
      addressId,
      deliveryAddressId,
      phoneNumber : contactData.phoneNumber,
      email : contactData.email,
    };
  
    addData(newData)
      .then(() => {
        clear();
        toast.success('Order has been added');
      })
  };
  
  const clear = () => {
    setCompanyClientDetailsData({
      companyName: "",
      nip: "",
    });
    setForename("");
    setSurname("");
    setAddressId("");
    setDeliveryAddressId("");
    setContactData({
      phoneNumber: "",
      email: "",
    });
  };


  const steps = [
    {
      name: "Address",
      component: (
        <Address
          addressId={addressId}
          deliveryAddressId={deliveryAddressId}
          setAddressId={setAddressId}
          setDeliveryAddressId={setDeliveryAddressId}
        />
      ),
    },
    {
      name: "Contact",
      component: (
        <Contact contactData={contactData} setContactData={setContactData} />
      ),
    },
    {
      name: "IndividualClientDetails",
      component: (
        <IndividualClientDetails
          forename={forename}
          surname={surname}
          setForename={setForename}
          setSurname={setSurname}
        />
      ),
    },
    {
      name: "CompanyClientDetails",
      component: (
        <CompanyClientDetails
          companyClientDetailsData={companyClientDetailsData}
          setCompanyClientDetailsData={setCompanyClientDetailsData}
        />
      ),
    },
  ];

  const nextStep = () => {
    if (currentStep < steps.length - 1) {
      setCurrentStep(currentStep + 1);
    }
  };

  const prevStep = () => {
    if (currentStep > 0) {
      setCurrentStep(currentStep - 1);
    }
  };

  return (
    <form className="order-form">
      <h2>{steps[currentStep].name}</h2>
      <div>{steps[currentStep].component}</div>
      <div style={{ marginTop: "20px" }}>
        <Button
          onClick={(e) => {
            e.preventDefault();
            prevStep();
          }}
          disabled={currentStep === 0}
        >
          Wstecz
        </Button>
        <Button
          onClick={(e) => {
            e.preventDefault();
            nextStep();
          }}
          disabled={currentStep === steps.length - 1}
        >
          Dalej
        </Button>
      </div>
      {(currentStep === steps.length - 1) ? 
      <Button className="btn btn-primary" onClick={handleSave}>
        Submit
      </Button>:null}
    </form>
  );
};

export default OrderForm;
