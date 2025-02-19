import React from "react";
import { Form } from "react-bootstrap";

import { useTranslation } from "react-i18next";
import securityFormFieldsProvider from "../helpers/securityFormFieldsProvider";
import FormControls from "../../Shared/FormControls";

const UserInfo = ({
  individualUserInfo,
  setIndividualUserInfo,
  companyUserInfo,
  setCompanyUserInfo,
  isCompany,
  setIsCompany,
  setIsValid,
}) => {
  const { t } = useTranslation();
  const handleSwichIsCompany = () => {
    setIsCompany((prev) => !prev);
  };
  return (
    <>
      <div className="register-companyValidatior">
        <Form.Label>Do you want register as a company?</Form.Label>
        <Form.Check
          type="switch"
          className="register-companyValidatior_checkbox"
          checked={isCompany}
          onChange={handleSwichIsCompany}
        />
      </div>
      {isCompany ? (
        <FormControls
          fields={securityFormFieldsProvider(t).companyUserInfo}
          data={companyUserInfo}
          setData={setCompanyUserInfo}
          setIsValid={setIsValid}
        />
      ) : (
        <FormControls
          fields={securityFormFieldsProvider(t).individualUserInfo}
          data={individualUserInfo}
          setData={setIndividualUserInfo}
          setIsValid={setIsValid}
        />
      )}
    </>
  );
};

export default UserInfo;
