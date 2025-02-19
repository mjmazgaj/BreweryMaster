import React from "react";
import { Button } from "react-bootstrap";

import { useTranslation } from 'react-i18next';

import "./shared.css"

import "bootstrap/dist/css/bootstrap.min.css";
import {
  Bs1Circle,
  Bs1CircleFill,
  Bs2Circle,
  Bs2CircleFill,
  Bs3Circle,
  Bs3CircleFill,
  Bs4Circle,
  Bs4CircleFill,
  Bs5Circle,
  Bs5CircleFill,
  Bs6Circle,
  Bs6CircleFill,
  Bs7Circle,
  Bs7CircleFill,
  BsThreeDots 
} from "react-icons/bs";

const MenuSteps = ({ currentStep, setCurrentStep, amountOfSteps, isValid = true }) => {
  const { t } = useTranslation();
  const stepIcons = [
    <Bs1Circle size={30} />,
    <Bs2Circle size={30} />,
    <Bs3Circle size={30} />,
    <Bs4Circle size={30} />,
    <Bs5Circle size={30} />,
    <Bs6Circle size={30} />,
    <Bs7Circle size={30} />,
  ];

  const stepFilledIcons = [
    <Bs1CircleFill size={30} />,
    <Bs2CircleFill size={30} />,
    <Bs3CircleFill size={30} />,
    <Bs4CircleFill size={30} />,
    <Bs5CircleFill size={30} />,
    <Bs6CircleFill size={30} />,
    <Bs7CircleFill size={30} />,
  ];

  const showSteps = () => {
    return stepIcons.map((icon, index) => {
      if (index >= amountOfSteps) return null;
      return (
        <div key={index}>
          <span>{index <= currentStep ? stepFilledIcons[index] : icon}</span>
          {index < stepFilledIcons.length - 1 && index < amountOfSteps - 1 ? (
            <BsThreeDots size={30} className="menu-steps_dots" />
          ) : null}
        </div>
      );
    });
  };
  
  const handleNextStep = (e) => {
    e.preventDefault();
    if (currentStep < amountOfSteps - 1 && isValid) {
      setCurrentStep(currentStep + 1);
    }
  };

  const handlePrevStep = (e) => {
    e.preventDefault();
    if (currentStep > 0 && isValid) {
      setCurrentStep(currentStep - 1);
    }
  };

  return (
    <div className="menu-steps__container">
      <div className="menu-steps__dots">{showSteps()}</div>

      <div className="menu-steps_buttons">
        <Button
          variant="dark"
          onClick={handlePrevStep}
          disabled={currentStep === 0 || !isValid}
        >
          {t("button.back")}
        </Button>
        <Button
          variant="dark"
          onClick={handleNextStep}
          disabled={currentStep === amountOfSteps - 1 || !isValid}
        >
          {t("button.next")}
        </Button>
      </div>
    </div>
  );
};

export default MenuSteps;
