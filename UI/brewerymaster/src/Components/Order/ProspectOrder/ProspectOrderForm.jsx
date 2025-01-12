import { React, useState, useEffect } from "react";
import { Button, Form } from "react-bootstrap";
import { toast } from "react-toastify";
import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';
import { addData } from '../api';

import ProspectOrderDetails from "./ProspectOrderDetails";
import MenuSteps from '../../Shared/MenuSteps';
import ClientDetails from "./ClientDetails";
import Contact from "../../Shared/Contact"

const ProspectOrderForm = () => {  
  
  const [contactData, setContactData] = useState({
    phoneNumber: "",
    email: "",
  });

  const [prospectOrderData, setProspectOrderData] = useState({
    selectedContainer: "",
    selectedBeer: "",
    capacity: "",
  });


  const [companyClientDetailsData, setCompanyClientDetailsData] = useState({
    companyName: "",
    nip: "",
  });
  
  const [individualClientDetailsData, setIndividualClientDetailsData] = useState({
    forename: "",
    surname: "",
  });
  const [isCompany, setIsCompany] = useState(0);

  const [currentStep, setCurrentStep] = useState(0);

  const handleSave = () => {
    const newData = {
      forename : contactData.forename,
      phoneNumber : contactData.phoneNumber,
      email : contactData.email,
      selectedBeer : prospectOrderData.selectedBeer,
      selectedContainer : prospectOrderData.selectedContainer,
      capacity : prospectOrderData.capacity,
      forename : individualClientDetailsData.forename,
      surname : individualClientDetailsData.surname,
      companyName : companyClientDetailsData.companyName,
      nip : companyClientDetailsData.nip,
      isCompany: isCompany
    };

    console.log(newData);
    // addData(newData)
    //   .then(() => {
    //     clear();
    //     toast.success("Order has been registered");
    //   })
    //   .catch((error) => console.log(error));
  };

  const clear = () => {
    setContactData({
      forename: "",
      phoneNumber: "",
      email: "",
    });
  };

  const steps = [
    {
      name: "Order",
      component: (
        <ProspectOrderDetails
          setProspectOrderData={setProspectOrderData}
          prospectOrderData={prospectOrderData}
        />
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
          isCompany={isCompany}
          setIsCompany={setIsCompany}
        />
      ),
    },
    {
      name: "Contact",
      component: (
        <Contact
          contactData={contactData}
          setContactData={setContactData}
        />
      ),
    },
  ];

  return (
    <form className="prospectorder-form">
      <MenuSteps
        currentStep={currentStep}
        setCurrentStep={setCurrentStep}
        amountOfSteps={steps.length}
      />

      <h2>{steps[currentStep].name}</h2>
      <div>{steps[currentStep].component}</div>

      {currentStep === steps.length - 1 ? (
        <Button variant="dark" onClick={handleSave}>
          Submit
        </Button>
      ) : null}
    </form>
  );
};

export default ProspectOrderForm;
