import React, {Fragment} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';

import ProspectOrderForm from "./ProspectOrderForm";
import BackgroundDetails from "../../Shared/BackgroundDetails";

const ProspectOrder = () => { 
    return (
      <Fragment>
        <BackgroundDetails />
        <ToastContainer />
        <div className="form-container">
          <ProspectOrderForm/>
        </div>
      </Fragment>
    );
}

export default ProspectOrder;