import React, { useState } from "react";

import DynamicTable from "../Shared/TableComponents/DynamicTable";
import CustomForm from "../Shared/CustomForm";

import { useTranslation } from "react-i18next";
import { useUser } from "./helpers/useUser";

const User = () => {
  const { t } = useTranslation();

  const [users, setUsers] = useState([]);
  const [filterData, setFilterData] = useState({});

  const { filterObject, filterFields, handleDoubleClick } = useUser({
    setUsers,
  });

  return (
    <div>
      <h2>{t("name.brewery.users")}</h2>
      <CustomForm
        fields={filterFields}
        formCustomizationObject={filterObject}
        data={filterData}
        setData={setFilterData}
      />
      <DynamicTable
        tableKey="users"
        tableTitle={t("user.userList")}
        dataCategory="user"
        data={users}
        handleDoubleClick={handleDoubleClick}
      />
    </div>
  );
};

export default User;
