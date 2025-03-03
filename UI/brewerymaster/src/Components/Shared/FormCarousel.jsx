import { React, useState } from "react";
import { Button, Form } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

import "./shared.css"

import MenuSteps from './MenuSteps';

const FormCarousel = ({steps, handleSave, isValid = true}) => {

  const [currentStep, setCurrentStep] = useState(0);

  return (
    <Form className="form-carousel_container">
      <MenuSteps
        currentStep={currentStep}
        setCurrentStep={setCurrentStep}
        amountOfSteps={steps.length}
        isValid={isValid}
      />

      <h2>{steps[currentStep].name}</h2>
      <div>{steps[currentStep].component}</div>

      {currentStep === steps.length - 1 && (
        <Button variant="dark" onClick={handleSave}>
          Zarejestruj
        </Button>
      )}
    </Form>
  );
};

export default FormCarousel;
