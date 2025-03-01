import { React, useState } from "react";

import ProspectOrderDetails from "../ProspectOrderDetails";
import ClientDetails from "../ClientDetails";

import { addData, apiEndpoints } from "../../../Shared/api";
import { useTranslation } from "react-i18next";
import FormBasic from "../../../Shared/FormBasic";

import prospectOrderFieldsProvider from "./prospectOrderFieldsProvider";

export const useProspectOrderForm = () => {
  const { t } = useTranslation();

  const [data, setData] = useState({
    isCompany: false,
  });
  const [isValid, setIsValid] = useState(true);

  const handleSave = () => {
    const companyClientData = {
      companyName: data.companyName,
      nip: data.nip,
    };
    const individualClientData = {
      forename: data.forename,
      surname: data.surname,
    };
    const newData = {
      client: {
        phoneNumber: data.phoneNumber,
        email: data.email,
        isCompany: data.isCompany,
        companyClient: data.isCompany ? { ...companyClientData } : null,
        individualClient: !data.isCompany ? { ...individualClientData } : null,
      },
      beerStyleId: data.beerStyleId,
      containerId: data.containerId,
      capacity: data.capacity,
      targetDate: data.targetDate,
    };
    console.log(newData)
    addData(apiEndpoints.prospectOrder, newData);
  };

  const steps = [
    {
      name: t("name.brewery.order"),
      component: (
        <ProspectOrderDetails
          setProspectOrderData={setData}
          prospectOrderData={data}
          setIsValid={setIsValid}
        />
      ),
    },
    {
      name: t("name.user.clientDetails"),
      component: (
        <ClientDetails data={data} setData={setData} setIsValid={setIsValid} />
      ),
    },
    {
      name: t("name.user.contact"),
      component: (
        <FormBasic
          fields={prospectOrderFieldsProvider(t).prospectOrderDetails}
          data={data}
          setData={setData}
          setIsValid={setIsValid}
        />
      ),
    },
  ];

  return {
    steps,
    handleSave,
  };
};
