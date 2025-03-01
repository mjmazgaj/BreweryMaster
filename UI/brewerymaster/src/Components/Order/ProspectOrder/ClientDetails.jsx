import React from "react";
import { Form } from "react-bootstrap";

import prospectOrderFieldsProvider from "./helpers/prospectOrderFieldsProvider";

import { useTranslation } from "react-i18next";
import FormControls from "../../Shared/FormControls";
const ClientDetails = ({ data, setData, setIsValid }) => {
  const { t } = useTranslation();
  const handleSwichIsCompany = () => {
    setData((prevData) => ({ ...prevData, isCompany: !prevData.isCompany }));
  };
  return (
    <>
      <div className="order-companyValidatior">
        <Form.Label>Do you want order as a company?</Form.Label>
        <Form.Check
          type="switch"
          className="order-companyValidatior_checkbox"
          checked={data.isCompany}
          onChange={handleSwichIsCompany}
        />
      </div>
      {data.isCompany ? (
        <FormControls
          fields={prospectOrderFieldsProvider(t).companyClientDetails}
          data={data}
          setData={setData}
          setIsValid={setIsValid}
        />
      ) : (
        <FormControls
          fields={prospectOrderFieldsProvider(t).individualClientDetails}
          data={data}
          setData={setData}
          setIsValid={setIsValid}
        />
      )}
    </>
  );
};

export default ClientDetails;
