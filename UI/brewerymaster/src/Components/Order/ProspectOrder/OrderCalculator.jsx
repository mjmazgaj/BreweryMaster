import React, { Fragment, useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../order.css";

import { fetchData, apiEndpoints } from "../../Shared/api";
import { useTranslation } from "react-i18next";

import ProspectOrderCheckPrice from "./ProspectOrderCheckPrice";
import BackgroundDetails from "../../Shared/BackgroundDetails";

import prospectOrderFieldsProvider from "./helpers/prospectOrderFieldsProvider";
import FormBasic from "../../Shared/FormBasic";

const OrderCalculator = () => {
  const { t } = useTranslation();

  const [calculatorData, setCalculatorData] = useState({});
  const [isValid, setIsValid] = useState(true);

  const [details, setDetails] = useState({});

  const fields = {
    control: prospectOrderFieldsProvider(t).calculator,
    dropdown: [
      {
        data: details.beerTypes,
        name: "selectedBeer",
        label: t("name.brewery.beerStyle"),
      },
      {
        data: details.containerTypes,
        name: "selectedContainer",
        label: t("name.brewery.container"),
      },
    ],
  };

  useEffect(() => {
    fetchData(apiEndpoints.prospectOrderDetails, setDetails);
  }, []);

  return (
    <Fragment>
      <BackgroundDetails />
      <div className="calculator_container">
        <h3>Kalkulator ceny zamówienia</h3>
        <p>{t("order.enterOrderDetails")}</p>
        <FormBasic
          fields={fields}
          data={calculatorData}
          setData={setCalculatorData}
          setIsValid={setIsValid}
        />

        <ProspectOrderCheckPrice prospectOrderData={calculatorData} isValid={isValid}/>
      </div>
    </Fragment>
  );
};

export default OrderCalculator;
