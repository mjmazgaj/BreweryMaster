import React from "react";

import DynamicTable from "./DynamicTable";
import ModalSingleInput from "../ModalSingleInput";

import { useDynamicTableSelection } from "../helpers/useDynamicTableSelection";

const DynamicTableSelection = ({sourceTableTitle, data, setData, targetTableTitle, selectedData, setSelectedData}) => { 

  const {
    handleDoubleClick,
    modalData,
    handleConfirmQuantity,
    setModalData,
  } = useDynamicTableSelection(data, setData, selectedData, setSelectedData);

  return (
    <div className={`table-selection_container`}>
      <DynamicTable
        tableKey="source-table"
        tableTitle={sourceTableTitle}
        data={data}
        handleDoubleClick={handleDoubleClick}
      />
      <DynamicTable
        tableKey="target-table"
        tableTitle={targetTableTitle}
        data={selectedData}
        handleDoubleClick={() => {}}
      />
      <ModalSingleInput
        modalData={modalData}
        handleConfirmQuantity={handleConfirmQuantity}
        setModalData={setModalData}
      />
    </div>
  );
};

export default DynamicTableSelection;