import React, { Fragment, useState} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import OrderForm from './OrderComponents/OrderForm';
import OrderSteps from './OrderComponents/OrderSteps';

const Order = () => {

  const [currentStep, setCurrentStep] = useState(0);

    return (
      <Fragment>
        <ToastContainer />
        <OrderSteps currentStep={currentStep}/>
        <OrderForm currentStep={currentStep} setCurrentStep={setCurrentStep}/>
      </Fragment>
    );
}

export default Order;