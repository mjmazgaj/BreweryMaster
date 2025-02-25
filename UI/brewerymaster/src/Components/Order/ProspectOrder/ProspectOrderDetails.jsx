import React, { Fragment, useState, useEffect } from "react";
import { Form } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import "../order.css";

import { fetchData, apiEndpoints } from "../../Shared/api";
import { useTranslation } from 'react-i18next';

import DropDownIndex from "../../Shared/DropDownIndex";
import ProspectOrderCheckPrice from "./ProspectOrderCheckPrice";

const ProspectOrderDetails = ({ prospectOrderData, setProspectOrderData }) => {
  const { t } = useTranslation();
  const handleInputChange = (key, e) => {
    const { value } = e.target;
    setProspectOrderData((prevData) => ({
      ...prevData,
      [key]: parseInt(value),
    }));
  };

  const [details, setDetails] = useState({});

  useEffect(() => {
    fetchData(apiEndpoints.prospectOrderDetails, setDetails);
  }, []);

  return (
    <Fragment>
      <div className="prospectorder-details">
        <p>{t("order.enterOrderDetails")}</p>
        <Form.Label>{t("name.brewery.capacity")}</Form.Label>
        <Form.Control
          id="capacity"
          type="number"
          placeholder={t("name.brewery.capacity")}
          onChange={(value) => handleInputChange("capacity", value)}
        />
        {details["beerTypes"] && (
          <DropDownIndex
            id={"beer-types"}
            data={details.beerTypes}
            selectedOption={prospectOrderData.selectedBeer}
            setSelectedOption={(value) =>
              handleInputChange("selectedBeer", value)
            }
            isReadOnly={false}
            label={t("name.brewery.beerStyle")}
          />
        )}
        {details["beerTypes"] && (
          <DropDownIndex
            id={"container-types"}
            data={details.containerTypes}
            selectedOption={prospectOrderData.selectedContainer}
            setSelectedOption={(value) =>
              handleInputChange("selectedContainer", value)
            }
            isReadOnly={false}
            label={t("name.brewery.container")}
          />
        )}
      </div>
      <ProspectOrderCheckPrice prospectOrderData={prospectOrderData} />
    </Fragment>
  );
};

export default ProspectOrderDetails;
