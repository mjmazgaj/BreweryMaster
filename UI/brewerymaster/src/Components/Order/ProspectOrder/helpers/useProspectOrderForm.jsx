import { React, useState } from "react";

import ProspectOrderDetails from "../ProspectOrderDetails";
import ClientDetails from "../ClientDetails";
import Contact from "../../../Shared/Contact"
import FormDatePicker from "../../../Shared/FormDatePicker";

import { addData } from '../../api';

export const useProspectOrderForm = () => {
  
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
      
      const [individualClientDetailsData, setIndividualClientDetailsData] = useState({
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
    
        addData(newData);
        clear();
      };
    
      const clear = () => {
        setContactData({
          phoneNumber: "",
          email: "",
        });
        setProspectOrderData ({
          selectedContainer: "",
          selectedBeer: "",
          capacity: "",
        });
        setCompanyClientDetailsData ({
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
          name: "Order",
          component: (
            <ProspectOrderDetails
              setProspectOrderData={setProspectOrderData}
              prospectOrderData={prospectOrderData}
            />
          ),
        },
        {
          name: "Client Details",
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
          name: "Contact",
          component: (
            <Contact
              contactData={contactData}
              setContactData={setContactData}
            />
          ),
        },
        {
          name: "Date",
          component: (
            <FormDatePicker
              id="complitionDate"
              key="complitionDate"
              label="Expected complition date"
              selectedDate={selectedDate}
              setSelectedDate={setSelectedDate}
            />
          ),
        },
      ];

  return {
    steps,
    handleSave
  };
};
