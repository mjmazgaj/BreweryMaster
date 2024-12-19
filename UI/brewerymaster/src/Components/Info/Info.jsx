import React, { useState} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import "./info.css"

import InfoTable from './InfoComponents/InfoTable';

const Info = () => {

    return (
      <div className="Info_container">
        <ToastContainer />
        <InfoTable />
      </div>
    );
}

export default Info;