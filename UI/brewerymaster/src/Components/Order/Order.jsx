import React, { useState} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import OrderForm from './OrderComponents/OrderForm';

const Order = () => {


    return (
        <div className="order_container">
          <ToastContainer />
          <OrderForm
          />
        </div>
    );
}

export default Order;