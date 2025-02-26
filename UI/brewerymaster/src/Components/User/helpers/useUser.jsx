import { useState, useEffect } from "react";

import userFieldsProvider from "./userFieldsProvider";
import { fetchData, apiEndpoints } from "../../Shared/api";
import { createPath } from "../../Shared/helpers/useObjectHelper";

import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";

export const useUser = ({ setUsers }) => {
  const { t } = useTranslation();
  const [roles, setRoles] = useState([]);
  const navigate = useNavigate();

  const filterObject = {
    submitFunction: (data) => fillUserTable(data),
    buttons: [
      {
        isSubmit: true,
        label: t("button.filter"),
      },
    ],
    classNamePrefix: "user-filter",
  };

  const dropdownData = [
    {
      id: true,
      name: t("name.general.true"),
    },
    {
      id: false,
      name: t("name.general.false"),
    },
  ];

  const fillUserTable = (data) => {
    let query = {
      email: data?.email,
      createdAfter: data?.createdAfter
        ? new Date(data.createdAfter).toISOString()
        : undefined,
      createdBefore: data?.createdBefore
        ? new Date(data.createdBefore).toISOString()
        : undefined,
      isCompany: data?.isCompany,
      roleId: data?.roleId,
    };

    const path = createPath(apiEndpoints.user, query);

    fetchData(path, setUsers);
  };

  const filterFields = {
    control: userFieldsProvider(t).filterFields.control,
    dropdown: [
      {
        data: dropdownData,
        name: "isCompany",
        label: t("name.user.isCompany"),
      },
      {
        data: roles.map((role) => ({
          id: role.id,
          name: t(`user.role.${role.name}`),
        })),
        name: "roleId",
        label: t("name.user.role"),
      },
    ],
    datePicker: [
      {
        name: "createdAfter",
        label: t("name.general.createdAfter"),
      },
      {
        name: "createdBefore",
        label: t("name.general.createdBefore"),
      },
    ],
  };

  useEffect(() => {
    fetchData(apiEndpoints.user, setUsers);
    fetchData(apiEndpoints.userRole, setRoles);
  }, []);

  const handleDoubleClick = (item) => {
    navigate(`/User/${item.id}`);
  };

  return { filterObject, filterFields, handleDoubleClick };
};
