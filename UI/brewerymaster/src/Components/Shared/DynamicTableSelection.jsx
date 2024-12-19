import React from "react";

import { useTranslation } from 'react-i18next';

import DynamicTable from "./DynamicTable";
import ModalSingleInput from "./ModalSingleInput";

import { useDynamicTableSelection } from "./helpers/useDynamicTableSelection";

const DynamicTableSelection = ({key, sourceTableKey, sourceTableTitle, data, setData, targetTableKey, targetTableTitle}) => { 
  const { t } = useTranslation();

  const {
    selectedData,
    handleDoubleClick,
    modalData,
    handleConfirmQuantity,
    setModalData,
  } = useDynamicTableSelection(data, setData);

  return (
    <div className={`recipe-${key}_container`}>
      <DynamicTable
        tableKey={sourceTableKey}
        tableTitle={sourceTableTitle}
        data={data}
        handleDoubleClick={handleDoubleClick}
      />
      <DynamicTable
        tableKey={targetTableKey}
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