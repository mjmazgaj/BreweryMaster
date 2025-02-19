import React, {useState} from "react";
import { Form } from "react-bootstrap";
import Button from 'react-bootstrap/Button';
import { toast } from "react-toastify";
import { addData } from '../../Shared/api';

import MenuSteps from '../../Shared/MenuSteps';
import RecipeTableSelection from "../OrderComponents/RecipeTableSelection";
import OrderFormStep2 from "./OrderFormStep2";

const OrderForm = () => {  

  const [orderData, setOrderData] = useState({});

  const [currentStep, setCurrentStep] = useState(0);

  const handleSave = async () => {
  
    await addData("Order", orderData);
  };
  
  const clear = () => {
  };

  const steps = [
    {
      name: "Please select a recipe",
      component: (
        <RecipeTableSelection
          selectedRecipe={orderData.recipeId}
          setSelectedRecipe={setOrderData}
        />
      ),
    },
    {
      name: "Specify following details",
      component: (
        <OrderFormStep2 data={orderData} setData={setOrderData} />
      ),
    }
  ];

  return (
    <Form className="order-form">
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
    </Form>
  );
};

export default OrderForm;