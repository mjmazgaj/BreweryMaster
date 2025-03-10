import React, { Fragment, useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "./order.css";
import { useTranslation } from "react-i18next";

import prospectOrderFieldsProvider from "./ProspectOrder/helpers/prospectOrderFieldsProvider";

import DynamicTable from "../Shared/TableComponents/DynamicTable";
import ModalItemAction from "../Shared/ModalComponents/ModalItemAction";
import ModalConfirmation from "../Shared/ModalComponents/ModalConfirmation";

import ModalForm from "../Shared/ModalComponents/ModalForm";
import { useProspectOrderSummary } from "./ProspectOrder/helpers/useProspectOrderSummary";
import CustomForm from "../Shared/CustomForm";

const ProspectOrderSummary = () => {
  const { t } = useTranslation();

  const [modalFormData, setModalFormData] = useState([]);

  const [data, setData] = useState([]);

  const [showItemAction, setShowItemAction] = useState(false);
  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  const [showModalForm, setShowModalForm] = useState(false);
  const [itemAction, setItemAction] = useState("default");
  const [modalAction, setModalAction] = useState("Edit");
    const [filterData, setFilterData] = useState([]);

  const [formFields, setFormFields] = useState({
    control: [],
    dropdown: [],
    checkBox: [],
  });

  const { handleDoubleClick, refreshTableData,
    filterObject, 
    filterFields } = useProspectOrderSummary({
    data,
    setData,
    setShowItemAction,
    setModalFormData,
    setFormFields,
  });

  return (
    <Fragment>
      <CustomForm
        fields={filterFields}
        formCustomizationObject={filterObject}
        data={filterData}
        setData={setFilterData}
      />

      {data && (
        <DynamicTable
          tableKey="prospectOrder"
          tableTitle={t("name.general.prospectOrder")}
          dataCategory="brewery"
          data={data}
          handleDoubleClick={handleDoubleClick}
        />
      )}

      <ModalItemAction
        fields={prospectOrderFieldsProvider(t).modalReadOnlyFields}
        data={modalFormData}
        show={showItemAction}
        setShow={setShowItemAction}
        setShowConfirmationModal={setShowConfirmationModal}
        setShowQuantityModal={() => {}}
        setShowModalForm={setShowModalForm}
        setModalAction={setModalAction}
        setQuantityAction={() => {}}
        action={itemAction}
        setAction={setItemAction}
      />

      <ModalForm
        fields={formFields}
        data={modalFormData}
        setData={setModalFormData}
        show={showModalForm}
        setShow={setShowModalForm}
        action={modalAction}
        itemName={t("name.general.prospectOrder")}
        refreshTableData={refreshTableData}
      />

      <ModalConfirmation
        id={modalFormData.id}
        name={`Prospect order from ${modalFormData.clientName} for ${modalFormData.beerStyle}`}
        confirmationAction="delete"
        show={showConfirmationModal}
        setShow={setShowConfirmationModal}
        path="ProspectOrder"
      />
    </Fragment>
  );
};

export default ProspectOrderSummary;
