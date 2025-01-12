import React, {useState} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';
import { toast } from "react-toastify";
import { addData } from '../api';

import Contact from './../../Shared/Contact'
import MenuSteps from '../../Shared/MenuSteps';
import Recipe from "./Recipe";

const OrderForm = () => {  

  const [selectedRecipe, setSelectedRecipe] = useState({});
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
      name: "Please select a recipe",
      component: (
        <Recipe
          selectedRecipe={selectedRecipe}
          setSelectedRecipe={setSelectedRecipe}
        />
      ),
    },
    {
      name: "Contact",
      component: (
        <Contact contactData={contactData} setContactData={setContactData} />
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