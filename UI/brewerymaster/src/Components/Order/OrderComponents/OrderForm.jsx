import React, {useState} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';
import { toast } from "react-toastify";
import { addData } from '../api';

import Address from './Address'
import ClientDetails from './ClientDetails'
import Contact from './../../Shared/Contact'
import MenuSteps from '../../Shared/MenuSteps';

const OrderForm = () => {  

  const [contactData, setContactData] = useState({
    phoneNumber: "",
    email: "",
  });

  const [companyClientDetailsData, setCompanyClientDetailsData] = useState({
    companyName: "",
    nip: "",
  });
  
  const [individualClientDetailsData, setIndividualClientDetailsData] = useState({
    forename: "",
    surname: "",
  });
  
  const [addressData, setAddressData] = useState({
    addressId: "",
    deliveryAddressId: "",
  });

  const [currentStep, setCurrentStep] = useState(0);

  const handleSave = () => {
    const newData = {
      forename : individualClientDetailsData.forename,
      surname : individualClientDetailsData.surname,
      companyName : companyClientDetailsData.companyName,
      nip : companyClientDetailsData.nip,
      addressId : addressData.addressId,
      deliveryAddressId : addressData.deliveryAddressId,
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
    setIndividualClientDetailsData({
      forename: "",
      surname: "",
    });
    setAddressData({
      addressId: "",
      deliveryAddressId: "",
    });
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
          addressData={addressData}
          setAddressData={setAddressData}
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
      name: "ClientDetails",
      component: (
        <ClientDetails
          individualClientDetailsData={individualClientDetailsData}
          setIndividualClientDetailsData={setIndividualClientDetailsData}
          companyClientDetailsData={companyClientDetailsData}
          setCompanyClientDetailsData={setCompanyClientDetailsData}
        />
      ),
    }
  ];

  return (
    <Form className="order-form">
      <MenuSteps currentStep={currentStep} setCurrentStep={setCurrentStep} amountOfSteps={steps.length} />

      <h2>{steps[currentStep].name}</h2>
      <div>{steps[currentStep].component}</div>

      {currentStep === steps.length - 1 ? (
        <Button variant="dark" onClick={handleSave}>
          Submit
        </Button>
      ) : null}
    </Form>
  );
};

export default OrderForm;