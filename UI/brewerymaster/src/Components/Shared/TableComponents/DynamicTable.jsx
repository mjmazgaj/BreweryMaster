import React from "react";
import {Table} from 'react-bootstrap';

import { useTranslation } from 'react-i18next';
import "../shared.css";

const DynamicTable = ({tableKey, tableTitle, data, handleDoubleClick}) => {  
  const { t } = useTranslation();

  const keys = data.length > 0 ? Object.keys(data[0]).filter(x=>x !== "id" && x !== "maxQuantity") : ["empty"];

  return (
    <div className={`dynamicTable-${tableKey}_container`}>
      <h3>{tableTitle}</h3>
      <Table striped bordered hover className="dynamicTable_table">
        <thead>
          <tr>
            {keys.map((header) => (
              <th key={header}>{t(`column.${header}`) || header}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data.length > 0 ? (
            data.map((item) => (
              <tr
                className="dynamicTable_row"
                key={item.id}
                onDoubleClick={() => handleDoubleClick(item)}
              >
                {keys.map((column) => (
                  <td>{item[column]}</td>
                ))}
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="5">Loading...</td>
            </tr>
          )}
        </tbody>
      </Table>
    </div>
  );
};

export default DynamicTable;