import { React, Fragment } from "react";

import 'bootstrap/dist/css/bootstrap.min.css'
import './order.css';

import FormCarousel from '../Shared/FormCarousel'
import BackgroundDetails from "./../Shared/BackgroundDetails";

import { useProspectOrderForm } from "./ProspectOrder/helpers/useProspectOrderForm";

const ProspectOrderForm = () => { 
  const {steps, handleSave} = useProspectOrderForm();

  return (
    <Fragment>
      <BackgroundDetails />
      <FormCarousel steps={steps} handleSave={handleSave} />
    </Fragment>
  );
};

export default ProspectOrderForm;
