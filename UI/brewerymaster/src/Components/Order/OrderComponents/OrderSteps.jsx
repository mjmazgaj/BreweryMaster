import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "react-toastify/dist/ReactToastify.css";
import {
  Bs1Circle,
  Bs1CircleFill,
  Bs2Circle,
  Bs2CircleFill,
  Bs3Circle,
  Bs3CircleFill,
  Bs4Circle,
  Bs4CircleFill,
  BsThreeDots 
} from "react-icons/bs";

const OrderSteps = ({ currentStep }) => {
  const stepIcons = [
    <Bs1Circle size={30} />,
    <Bs2Circle size={30} />,
    <Bs3Circle size={30} />,
    <Bs4Circle size={30} />,
  ];

  const stepFilledIcons = [
    <Bs1CircleFill size={30} />,
    <Bs2CircleFill size={30} />,
    <Bs3CircleFill size={30} />,
    <Bs4CircleFill size={30} />,
  ];

  const showSteps = () => {
    return stepIcons.map((icon, index) => (
      <div>
        <span key={index}>
          {index <= currentStep ? stepFilledIcons[index] : icon}
        </span>
          {index < stepFilledIcons.length - 1 ? <BsThreeDots size={30} className="order-steps_dots"/> : null}
      </div>
    ));
  };

  return <div className="order-steps">{showSteps()}</div>;
};

export default OrderSteps;
