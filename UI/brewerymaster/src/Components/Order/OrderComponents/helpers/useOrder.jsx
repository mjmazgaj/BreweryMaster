import { useState, useEffect } from "react";

import fieldsProvider from "./fieldsProvider";
import { fetchData } from "../../../Shared/api";
import { createPath } from "../../../Shared/helpers/useObjectHelper";

import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";

export const useOrder = ({ user, setData }) => {
  const { t } = useTranslation();
  const navigate = useNavigate();

  const [users, setUsers] = useState([]);
  const filterObject = {
    submitFunction: (data) => fillUserTable(data),
    buttons: [
      {
        isSubmit: true,
        label: t("button.filter"),
      },
    ],
    classNamePrefix: "order-filter",
  };

  const fillUserTable = (data) => {
    let query = {
      createdBy: data?.createdBy,
      expectedAfter: data?.expectedAfter
        ? new Date(data.expectedAfter).toISOString()
        : undefined,
      expectedBefore: data?.expectedBefore
        ? new Date(data.expectedBefore).toISOString()
        : undefined,
      recipeName: data?.recipeName,
    };

    const path = createPath("Order/All", query);

    fetchData(path, setData);
  };

  const filterFields = {
    control: fieldsProvider(t).filterFields.control,
    dropdown: [
      {
        data: users,
        name: "createdBy",
        label: t("name.brewery.createdBy"),
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
    if (user?.roles?.includes("customer")) fetchData("Order", setData);
    else fetchData("Order/All", setData);
    fetchData("User", setUsers);
  }, []);

  const handleDoubleClick = (item) => {
    navigate(`/Order/${item.id}`);
  };

  return { filterObject, filterFields, handleDoubleClick };
};
