import React, { useState, useEffect } from "react";

import DynamicTable from "../Shared/TableComponents/DynamicTable";

import { useTranslation } from "react-i18next";

import {fetchUsers} from "./api"

const User = () => {
  const { t } = useTranslation();

  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetchUsers(setUsers);
  }, []);


  return (
    <div>
      <h2>User</h2>
      <DynamicTable
          tableKey="users"
          tableTitle="All users"
          data={users}
          handleDoubleClick={()=>console.log("it works")}
        />
    </div>
  );
};

export default User;
