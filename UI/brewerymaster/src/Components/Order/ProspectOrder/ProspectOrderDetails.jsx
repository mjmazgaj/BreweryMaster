import React, { Fragment, useState, useEffect } from "react";
import "../order.css";

import { fetchData, apiEndpoints } from "../../Shared/api";
import { useTranslation } from "react-i18next";

import prospectOrderFieldsProvider from "./helpers/prospectOrderFieldsProvider";

import FormBasic from "../../Shared/FormBasic";

const ProspectOrderDetails = ({
  prospectOrderData,
  setProspectOrderData,
  setIsValid,
}) => {
  const { t } = useTranslation();
  const [details, setDetails] = useState({});

  const fields = {
    control: prospectOrderFieldsProvider(t).calculator,
    dropdown: [
      {
        data: details.beerTypes,
        name: "beerStyleId",
        label: t("name.brewery.beerStyle"),
      },
      {
        data: details.containerTypes,
        name: "containerId",
        label: t("name.brewery.container"),
      },
    ],
  };

  useEffect(() => {
    fetchData(apiEndpoints.prospectOrderDetails, setDetails);
  }, []);

  return (
    <Fragment>
      <div className="prospectorder-details">
        <p>{t("order.enterOrderDetails")}</p>
        <FormBasic
          fields={fields}
          data={prospectOrderData}
          setData={setProspectOrderData}
          setIsValid={setIsValid}
        />
      </div>
    </Fragment>
  );
};

export default ProspectOrderDetails;
