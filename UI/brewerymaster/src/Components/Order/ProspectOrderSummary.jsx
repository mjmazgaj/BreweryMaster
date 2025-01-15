import React, {Fragment, useState, useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import './order.css';
import { fetchData } from "./api";

import DynamicTable from "../Shared/TableComponents/DynamicTable";

const ProspectOrderSummary = () => { 
    const [data, setData] = useState([]);

    const handleDoubleClick = (item) => {
      console.log(item);
    };

  useEffect(() => {
    fetchData(setData);
  }, []);

    return (
      <Fragment>
        {data && (
          <DynamicTable
            tableKey="prospectOrder"
            tableTitle="Prospect orders"
            data={data}
            handleDoubleClick={handleDoubleClick}
          />
        )}

      </Fragment>
    );
}

export default ProspectOrderSummary;