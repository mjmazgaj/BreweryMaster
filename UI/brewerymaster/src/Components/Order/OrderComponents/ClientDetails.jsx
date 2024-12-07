import React, {useState} from "react";
import { Form, Button } from "react-bootstrap";

import CompanyClientDetails from './CompanyClientDetails';
import IndividualClientDetails from './IndividualClientDetails';

const ClientDetails = ({
  individualClientDetailsData,
  setIndividualClientDetailsData,
  companyClientDetailsData,
  setCompanyClientDetailsData
}) => {
  
  const[isCompany, setIsCompany] = useState(false);
  const handleSwichIsCompany = () =>{
    setIsCompany((prev) => !prev);
  }
  return (
    <>
      <div className="order-companyValidatior">
        <Form.Label>Do you want order as a company?</Form.Label>
        <Form.Check
          type="switch"
          className="order-companyValidatior_checkbox"
          value={isCompany}
          onClick={handleSwichIsCompany}
        />
      </div>
      {isCompany ? (
        <CompanyClientDetails
          companyClientDetailsData={companyClientDetailsData}
          setCompanyClientDetailsData={setCompanyClientDetailsData}
        />
      ) : (
        <IndividualClientDetails
          individualClientDetailsData={individualClientDetailsData}
          setIndividualClientDetailsData={setIndividualClientDetailsData}
        />
      )}
    </>
  );
};

export default ClientDetails;
