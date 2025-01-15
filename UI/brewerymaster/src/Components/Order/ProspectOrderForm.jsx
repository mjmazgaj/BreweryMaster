import { React, useState, Fragment } from "react";
import { Button, Form } from "react-bootstrap";

import 'bootstrap/dist/css/bootstrap.min.css'
import './order.css';

import MenuSteps from '../Shared/MenuSteps';
import BackgroundDetails from "./../Shared/BackgroundDetails";

import { useProspectOrderForm } from "./ProspectOrder/helpers/useProspectOrderForm";

const ProspectOrderForm = () => {  
  
  const [currentStep, setCurrentStep] = useState(0);

  const {steps, handleSave} = useProspectOrderForm();

  return (
    <Fragment>
      <BackgroundDetails />
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
    </Fragment>
  );
};

export default ProspectOrderForm;
