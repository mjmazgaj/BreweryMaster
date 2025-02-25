import React, { useState } from "react";
import { Form } from "react-bootstrap";
import Button from "react-bootstrap/Button";
import { toast } from "react-toastify";
import { addData, fetchData, apiEndpoints } from "../../Shared/api";

import { useTranslation } from "react-i18next";

import MenuSteps from "../../Shared/MenuSteps";
import RecipeTableSelection from "../OrderComponents/RecipeTableSelection";
import OrderFormStep2 from "./OrderFormStep2";

const OrderForm = ({ setData, setIsAddMode }) => {
  const { t } = useTranslation();
  const [orderData, setOrderData] = useState({});
  const [isValid, setIsValid] = useState(false);

  const [currentStep, setCurrentStep] = useState(0);

  const handleSave = async () => {
    await addData(apiEndpoints.order, orderData);
    fetchData(apiEndpoints.orderAll, setData);
    setIsAddMode(false);
  };

  const clear = () => {};

  const steps = [
    {
      name: t("order.selectRecipeTitle"),
      component: (
        <RecipeTableSelection
          selectedRecipe={orderData}
          setSelectedRecipe={setOrderData}
          setIsValid={setIsValid}
        />
      ),
    },
    {
      name: t("order.addOrderDetails"),
      component: (
        <OrderFormStep2
          data={orderData}
          setData={setOrderData}
          setIsValid={setIsValid}
        />
      ),
    },
  ];

  return (
    <Form className="order-form">
      <MenuSteps
        currentStep={currentStep}
        setCurrentStep={setCurrentStep}
        amountOfSteps={steps.length}
        isValid={isValid}
      />

      <h2>{steps[currentStep].name}</h2>
      <div>{steps[currentStep].component}</div>
      {currentStep === steps.length - 1 ? (
        <Button variant="dark" onClick={handleSave}>
          {t("button.submit")}
        </Button>
      ) : null}
    </Form>
  );
};

export default OrderForm;
