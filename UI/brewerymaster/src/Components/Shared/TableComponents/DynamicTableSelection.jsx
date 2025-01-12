import React, { useState } from "react";

import DynamicTable from "./DynamicTable";

import { useTranslation } from 'react-i18next';
import { useDynamicTableSelection } from "./helpers/useDynamicTableSelection";

import modalFieldsProvider from "../../Shared/ModalComponents/helpers/modalFieldsProvider";
import ModalRecipeQuantity from "../ModalComponents/ModalRecipeQuantity";

const DynamicTableSelection = ({sourceTableTitle, data, selectedData, setSelectedData, quantityAction}) => { 

  const { t } = useTranslation();
  const [showQuantityModal, setShowQuantityModal] = useState(false);

  const { handleDoubleClick, modalData } =
    useDynamicTableSelection(setShowQuantityModal);

  return (
    <div className={`table-selection_container`}>
      <DynamicTable
        tableKey="source-table"
        tableTitle={sourceTableTitle}
        data={data.map((item)=>({...item, quantity:selectedData[item.id]?.quantity ?? 0}))}
        handleDoubleClick={handleDoubleClick}
      />
      <ModalRecipeQuantity
        fields={modalFieldsProvider(t).quantityModalFields[quantityAction.area]}
        modalData={modalData}
        setSelectedData={setSelectedData}
        show={showQuantityModal}
        setShow={setShowQuantityModal}
        action={quantityAction}
        isEmpty={false}
      />
    </div>
  );
};

export default DynamicTableSelection;