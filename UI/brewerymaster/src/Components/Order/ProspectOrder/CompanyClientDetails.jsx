import React from "react";
import { Form } from "react-bootstrap";

const CompanyClientDetails = ({
  companyClientDetailsData,
  setCompanyClientDetailsData,
}) => {
  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setCompanyClientDetailsData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  return (
    <div className="form-company-client-details">
      <Form.Label>Company Name</Form.Label>
      <Form.Control
        id="companyName"
        type="text"
        placeholder="Enter Company Name"
        value={companyClientDetailsData.companyName}
        onChange={handleInputChange}
      />
      <Form.Label>NIP</Form.Label>
      <Form.Control
        id="nip"
        type="text"
        placeholder="Enter nip"
        value={companyClientDetailsData.nip}
        onChange={handleInputChange}
      />
    </div>
  );
};

export default CompanyClientDetails;
