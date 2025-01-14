import { React, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { toast } from "react-toastify";

import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';

import MenuSteps from '../../Shared/MenuSteps';

import { useProspectOrderForm } from "./helpers/useProspectOrderForm";

const ProspectOrderForm = () => {  
  
  const [currentStep, setCurrentStep] = useState(0);

  const {steps, handleSave} = useProspectOrderForm();

  return (
    <form className="prospectorder-form">
      <MenuSteps
        currentStep={currentStep}
        setCurrentStep={setCurrentStep}
        amountOfSteps={steps.length}
      />

      <h2>{steps[currentStep].name}</h2>
      <div>{steps[currentStep].component}</div>

      {currentStep === steps.length - 1 && (
        <Button variant="dark" onClick={handleSave}>
          Submit
        </Button>
      )}
    </form>
  );
};

export default ProspectOrderForm;
