import React, {Fragment, useState, useEffect} from "react";
import { fetchData, fetchDetails } from "../../api";
import { useTranslation } from "react-i18next";
import modalFieldsProvider from "./modalFieldsProvider";

export const useProspectOrderSummary = ({data, 
  setData,
  setShowItemAction,
  setModalFormData,
  setFormFields}) => {
    const { t } = useTranslation();
    const [details, setDetails] = useState({});

    const handleDoubleClick = (item) => {
        setFormData(item);
        setShowItemAction(true);
      };


      const setFormData = (item) => {
          setModalFormData({
            id: item.id,
            name: "Prospect order",
            clientName: item.clientName,
            email: item.email,
            phoneNumber: item.phoneNumber,
            beerStyle: item.beerStyle,
            beerStyleId: parseInt(item.beerStyleId),
            container: item.container,
            containerTypeId: parseInt(item.containerTypeId),
            capacity: item.capacity,
            isClosedString: `${item.isClosed}`,
            isClosed: item.isClosed,
          });
    
          setFormFields({
            control: modalFieldsProvider(t).prospectOrderModalModalFields,
            dropdown: [
              {
                data: details.beerTypes,
                name: "beerStyleId",
                label: "Beer style",
              },
              {
                data: details.containerTypes,
                name: "containerTypeId",
                label: "Container type",
              },
            ],
            checkBox: [
              {
                id: 1,
                name: "isClosed",
                label: "Is order closed",
                isChecked: item.isClosed,
              },
            ],
          });
        };
        
          useEffect(() => {
            fetchData(setData);
            fetchDetails(setDetails);
          }, [data]);

  return {
    handleDoubleClick
  };
};