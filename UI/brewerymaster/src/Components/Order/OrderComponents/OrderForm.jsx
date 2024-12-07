import React, {useState} from "react";
import { Form, Button } from "react-bootstrap";
import { toast } from "react-toastify";
import { addData } from '../api';

import Address from './Address'
import ClientDetails from './ClientDetails'
import Contact from './../../Shared/Contact'
import OrderSteps from './OrderSteps';

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

  const handleNextStep = (e) => {
    e.preventDefault();
    if (currentStep < steps.length - 1) {
      setCurrentStep(currentStep + 1);
    }
  };

  const handlePrevStep = (e) => {
    e.preventDefault();
    if (currentStep > 0) {
      setCurrentStep(currentStep - 1);
    }
  };

  return (
    <form className="order-form">
      <OrderSteps currentStep={currentStep} amountOfSteps={steps.length} />

      <div className="order-steps_buttons">
        <Button onClick={handlePrevStep} disabled={currentStep === 0}>
          Back
        </Button>
        <Button
          onClick={handleNextStep}
          disabled={currentStep === steps.length - 1}
        >
          Next
        </Button>
      </div>
      <h2>{steps[currentStep].name}</h2>
      <div>{steps[currentStep].component}</div>

      {currentStep === steps.length - 1 ? (
        <Button className="btn btn-primary" onClick={handleSave}>
          Submit
        </Button>
      ) : null}
    </form>
  );
};

export default OrderForm;
