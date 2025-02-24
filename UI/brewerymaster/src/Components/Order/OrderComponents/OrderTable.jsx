import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../order.css";

import { fetchData } from "../../Shared/api";
import { useNavigate } from "react-router-dom";
import { useUser } from "../../Security/UserProvider";

import { useTranslation } from "react-i18next";

import DynamicTable from "../../Shared/TableComponents/DynamicTable";

import { useOrder } from "./helpers/useOrder";
import CustomForm from "../../Shared/CustomForm";

const OrderTable = ({data, setData}) => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { user } = useUser();

  const [filterData, setFilterData] = useState([]);

  const { filterObject, filterFields, handleDoubleClick } = useOrder({
    user,
    setData
  });

  return (
    <div className="recipe-table">
      <CustomForm
        fields={filterFields}
        formCustomizationObject={filterObject}
        data={filterData}
        setData={setFilterData}
      />
      {data && (
        <DynamicTable
          tableKey="orders"
          tableTitle={t("name.brewery.orders")}
          dataCategory="brewery"
          data={data}
          handleDoubleClick={handleDoubleClick}
        />
      )}
    </div>
  );
};

export default OrderTable;
