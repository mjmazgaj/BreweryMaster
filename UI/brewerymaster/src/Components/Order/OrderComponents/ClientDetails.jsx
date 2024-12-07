import React from 'react';

import CompanyClientDetails from './CompanyClientDetails';
import IndividualClientDetails from './IndividualClientDetails';

const ClientDetails = ({
  individualClientDetailsData,
  setIndividualClientDetailsData,
  companyClientDetailsData,
  setCompanyClientDetailsData,
  isCompany
}) => {

  return (
    <>
      {(isCompany) ?
      <CompanyClientDetails
        companyClientDetailsData={companyClientDetailsData}
        setCompanyClientDetailsData={setCompanyClientDetailsData}
      />
      :
      <IndividualClientDetails
        individualClientDetailsData={individualClientDetailsData}
        setIndividualClientDetailsData={setIndividualClientDetailsData}
      />}
    </>
  );
};

export default ClientDetails;
