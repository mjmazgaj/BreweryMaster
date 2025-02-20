import { React, useState } from "react";

import ProspectOrderDetails from "../ProspectOrderDetails";
import ClientDetails from "../ClientDetails";
import Contact from "../../../Shared/Contact";
import FormDatePicker from "../../../Shared/FormDatePicker";

import { addData } from "../../../Shared/api";
import { useTranslation } from 'react-i18next';

export const useProspectOrderForm = () => {
  const { t } = useTranslation();
  const [contactData, setContactData] = useState({
    phoneNumber: "",
    email: "",
  });

  const [prospectOrderData, setProspectOrderData] = useState({
    selectedContainer: "",
    selectedBeer: "",
    capacity: "",
  });

  const [companyClientDetailsData, setCompanyClientDetailsData] = useState({
    companyName: "",
    nip: "",
  });

  const [individualClientDetailsData, setIndividualClientDetailsData] =
    useState({
      forename: "",
      surname: "",
    });
  const [isCompany, setIsCompany] = useState(false);
  const [selectedDate, setSelectedDate] = useState(null);

  const handleSave = () => {
    const newData = {
      forename: individualClientDetailsData.forename,
      surname: individualClientDetailsData.surname,
      phoneNumber: contactData.phoneNumber,
      email: contactData.email,
      beerStyleId: prospectOrderData.selectedBeer,
      containerId: prospectOrderData.selectedContainer,
      capacity: prospectOrderData.capacity,
      companyName: companyClientDetailsData.companyName,
      nip: companyClientDetailsData.nip,
      targetDate: selectedDate,
      isCompany: isCompany,
    };

    addData("ProspectOrder", newData);
    clear();
  };

  const clear = () => {
    setContactData({
      phoneNumber: "",
      email: "",
    });
    setProspectOrderData({
      selectedContainer: "",
      selectedBeer: "",
      capacity: "",
    });
    setCompanyClientDetailsData({
      companyName: "",
      nip: "",
    });
    setIndividualClientDetailsData({
      forename: "",
      surname: "",
    });
    setIsCompany(false);
    setSelectedDate(null);
  };

  const steps = [
    {
      name: t("name.brewery.order"),
      component: (
        <ProspectOrderDetails
          setProspectOrderData={setProspectOrderData}
          prospectOrderData={prospectOrderData}
        />
      ),
    },
    {
      name: t("name.user.clientDetails"),
      component: (
        <ClientDetails
          individualClientDetailsData={individualClientDetailsData}
          setIndividualClientDetailsData={setIndividualClientDetailsData}
          companyClientDetailsData={companyClientDetailsData}
          setCompanyClientDetailsData={setCompanyClientDetailsData}
          isCompany={isCompany}
          setIsCompany={setIsCompany}
        />
      ),
    },
    {
      name: t("name.user.contact"),
      component: (
        <Contact contactData={contactData} setContactData={setContactData} />
      ),
    },
    {
      name: t("name.brewery.date"),
      component: (
        <FormDatePicker
          id="complitionDate"
          key="complitionDate"
          label={t("name.brewery.expectedDate")}
          selectedDate={selectedDate}
          setSelectedDate={setSelectedDate}
        />
      ),
    },
  ];

  return {
    steps,
    handleSave,
  };
};
