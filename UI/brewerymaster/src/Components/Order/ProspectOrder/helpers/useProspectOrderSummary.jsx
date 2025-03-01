import React, { Fragment, useState, useEffect } from "react";
import { fetchData, apiEndpoints } from "../../../Shared/api";
import { useTranslation } from "react-i18next";
import prospectOrderFieldsProvider from "./prospectOrderFieldsProvider";
import { createPath } from "../../../Shared/helpers/useObjectHelper";

export const useProspectOrderSummary = ({
  data,
  setData,
  setShowItemAction,
  setModalFormData,
  setFormFields,
}) => {
  const { t } = useTranslation();
  const [details, setDetails] = useState({});
  const [clients, setClients] = useState([]);
  const [beerStyles, setBeerStyles] = useState([]);

  const handleDoubleClick = (item) => {
    setFormData(item);
    setShowItemAction(true);
  };

  const setFormData = (item) => {
    setModalFormData({
      id: item.id,
      name: t("name.general.prospectOrder"),
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
      targetDate: item.targetDate,
    });

    setFormFields({
      control: prospectOrderFieldsProvider(t).modalModalFields,
      dropdown: [
        {
          data: details.beerTypes,
          name: "beerStyleId",
          label: t("name.brewery.style"),
        },
        {
          data: details.containerTypes,
          name: "containerTypeId",
          label: t("name.brewery.container"),
        },
      ],
      checkBox: [
        {
          id: 1,
          name: "isClosed",
          label: t("name.brewery.isClosed"),
          isChecked: item.isClosed,
        },
      ],
      datePicker: [
        {
          name: "targetDate",
          label: t("name.brewery.targetDate"),
        },
      ],
    });
  };

  const refreshTableData = () => fetchData(apiEndpoints.prospectOrder, setData);

  const filterObject = {
    submitFunction: (data) => fillUserTable(data),
    buttons: [
      {
        isSubmit: true,
        label: t("button.filter"),
      },
    ],
    classNamePrefix: "prospect-order-filter",
  };

  const fillUserTable = (data) => {
    let query = {
      clientId: data?.clientId,
      expectedAfter: data?.expectedAfter
        ? new Date(data.expectedAfter).toISOString()
        : undefined,
      expectedBefore: data?.expectedBefore
        ? new Date(data.expectedBefore).toISOString()
        : undefined,
      beerStyleId: data?.beerStyleId,
    };

    const path = createPath(apiEndpoints.prospectOrder, query);

    fetchData(path, setData);
  };

  const filterFields = {
    dropdown: [
      {
        data: clients,
        name: "clientId",
        label: t("name.brewery.clientName"),
      },
      {
        data: beerStyles,
        name: "beerStyleId",
        label: t("name.brewery.beerStyle"),
      },
    ],
    datePicker: [
      {
        name: "expectedAfter",
        label: t("name.brewery.expectedAfter"),
      },
      {
        name: "expectedBefore",
        label: t("name.brewery.expectedBefore"),
      },
    ],
  };

  useEffect(() => {
    refreshTableData();
    fetchData(apiEndpoints.prospectOrderDetails, setDetails);
    fetchData(apiEndpoints.prospectClientDropDown, setClients);
    fetchData(apiEndpoints.recipeBeerStyleDropDown, setBeerStyles);
  }, []);

  return {
    handleDoubleClick,
    refreshTableData,
    filterObject,
    filterFields,
  };
};
