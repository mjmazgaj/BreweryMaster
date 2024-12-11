import React, {useState} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';
import { toast } from "react-toastify";

import { addData } from '../api';

import MenuSteps from '../../Shared/MenuSteps';
import RecipeFirstStep from "./RecipeFirstStep";

const RecipeForm = () => {  

  const [currentStep, setCurrentStep] = useState(0);

  const handleSave = () => {
    const newData = {
    };
  
    addData(newData)
      .then(() => {
        clear();
        toast.success('Recipe has been added');
      })
  };
  
  const clear = () => {
  };

  const steps = [
    {
      name: "test",
      component: <RecipeFirstStep />,
    },
  ];

  return (
    <Form className="recipe-form">
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

export default RecipeForm;