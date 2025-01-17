import React, {Fragment, useState, useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import './order.css';
import { useTranslation } from "react-i18next";

import modalFieldsProvider from "./ProspectOrder/helpers/modalFieldsProvider";

import DynamicTable from "../Shared/TableComponents/DynamicTable";
import ModalItemAction from "../Shared/ModalComponents/ModalItemAction"
import ModalConfirmation from "../Shared/ModalComponents/ModalConfirmation"

import ModalFormBasic from "../Shared/ModalComponents/ModalFormBasic";
import {useProspectOrderSummary} from "./ProspectOrder/helpers/useProspectOrderSummary";

const ProspectOrderSummary = () => { 
  const { t } = useTranslation();

  const [modalFormData, setModalFormData] = useState([]);

  const [data, setData] = useState([]);

  const [showItemAction, setShowItemAction] = useState(false);
  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  const [showModalForm, setShowModalForm] = useState(false);
  const [itemAction, setItemAction] = useState("default");
  const [modalAction, setModalAction] = useState("edit");


  const [formFields, setFormFields] = useState({
    control: [],
    dropdown: [],
    checkBox: [],
  });
  

  const {handleDoubleClick} = useProspectOrderSummary({data, 
    setData,
    setShowItemAction,
    setModalFormData,
    setFormFields});

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

        <ModalItemAction
          fields={modalFieldsProvider(t).prospectOrderModalReadOnlyFields}
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

        <ModalFormBasic
          fields={formFields}
          data={modalFormData}
          setData={setModalFormData}
          show={showModalForm}
          setShow={setShowModalForm}
          action={modalAction}
          itemName="Prospect order"
        />

        <ModalConfirmation
          id={modalFormData.id}
          name={`Prospect order from ${modalFormData.clientName} for ${modalFormData.beerStyle}`}
          confirmationAction="delete"
          show={showConfirmationModal}
          setShow={setShowConfirmationModal}
        />

      </Fragment>
    );
}

export default ProspectOrderSummary;