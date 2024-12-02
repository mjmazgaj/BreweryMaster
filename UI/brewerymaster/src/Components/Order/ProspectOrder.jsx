import React, {useState, useEffect, Fragment} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import './order.css';

import ProspectOrderForm from "./ProspectOrderForm";

const ProspectOrder = () => { 
    return (
      <Fragment>
        <div className="background-details">
          <div className="left-image">
            <img src="./glass.png" alt="" />
          </div>
          <div className="right-image">
            <img src="./bottle.png" alt="" />
          </div>
        </div>
        <ToastContainer />
        <div className="form-container">
          <ProspectOrderForm/>
        </div>
      </Fragment>
    );
}

export default ProspectOrder;