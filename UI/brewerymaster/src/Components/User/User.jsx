import React, { useState, useEffect } from "react";

import DynamicTable from "../Shared/TableComponents/DynamicTable";

import { useTranslation } from "react-i18next";

import { useNavigate } from "react-router-dom";
import { fetchData } from "../Shared/api";

const User = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();

  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetchData("User", setUsers);
  }, []);

  const handleDoubleClick = (item) => {
    navigate(`/User/${item.id}`)
  };

  return (
    <div>
      <h2>User</h2>
      <DynamicTable
        tableKey="users"
        tableTitle="All users"
        dataCategory="user"
        data={users}
        handleDoubleClick={handleDoubleClick}
      />
    </div>
  );
};

export default User;
