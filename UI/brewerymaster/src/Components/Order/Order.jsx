import React, { Fragment} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import OrderForm from './OrderComponents/OrderForm';

const Order = () => {

    return (
      <Fragment>
        <ToastContainer />
        <OrderForm />
      </Fragment>
    );
}

export default Order;