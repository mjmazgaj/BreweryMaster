import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "react-toastify/dist/ReactToastify.css";
import "../order.css";

import { fetchData } from "../../Shared/api";
import { useNavigate } from "react-router-dom";
import { useUser } from "../../Security/UserProvider";

import DynamicTable from "../../Shared/TableComponents/DynamicTable";

const OrderTable = () => {
  const navigate = useNavigate();
  const { user } = useUser();

  const [data, setData] = useState([]);

  const handleDoubleClick = (item) => {
    console.log(item);
    navigate(`/Order/${item.id}`);
  };

  useEffect(() => {
    if (user?.roles?.includes("customer")) fetchData("Order", setData);
    else fetchData("Order/All", setData);
  }, []);

  return (
    <div className="recipe-table">
      {data && (
        <DynamicTable
          tableKey="orders"
          tableTitle="Orders"
          dataCategory="brewery"
          data={data}
          handleDoubleClick={handleDoubleClick}
        />
      )}
    </div>
  );
};

export default OrderTable;
