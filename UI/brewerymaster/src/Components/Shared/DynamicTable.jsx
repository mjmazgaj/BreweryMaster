import React from "react";

import { useTranslation } from 'react-i18next';
import "./shared.css";

const DynamicTable = ({tableKey, tableTitle, data, handleDoubleClick}) => {  
  const { t } = useTranslation();

  const headers = data.length > 0 ? Object.keys(data[0]).filter(x=>x !== "id") : ["empty"];

  return (
    <div className={`dynamicTable-${tableKey}_container`}>
      <h3>{tableTitle}</h3>
      <table className="dynamicTable_table">
        <thead>
          <tr>
            {headers.map((header) => (
              <th key={header}>{t(`common.${header}`) || header}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data.map((item) => (
            <tr
              key={item.id}
              onDoubleClick={() => handleDoubleClick(item)}
            >
              <td>{item.name}</td>
              <td>{item.quantity}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default DynamicTable;