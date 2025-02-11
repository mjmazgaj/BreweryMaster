import React, { useState, useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';

import {fetchData} from "../../Shared/api"

import DynamicTable from "../../Shared/TableComponents/DynamicTable";

const OrderTable = () => {

const [data, setData] = useState([]);

const handleDoubleClick = (item) =>{
    console.log(item);
}

  useEffect(() => {
    fetchData("Order", setData);
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
}

export default OrderTable;