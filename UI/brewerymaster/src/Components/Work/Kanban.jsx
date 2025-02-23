import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import KanbanBoard from "./KanbanComponents/KanbanBoard";
import "./kanban.css";

import { useTranslation } from "react-i18next";
import ModalFormBasic from "../Shared/ModalComponents/ModalFormBasic";

import { useKanban } from "./KanbanComponents/helpers/useKanban";

import fieldsProvider from "./KanbanComponents/helpers/fieldsProvider";
import CustomForm from "../Shared/CustomForm";

const Kanban = () => {
  const { t } = useTranslation();
  const [columns, setColumns] = useState(null);
  const [data, setData] = useState({});
  const [isValid, setIsValid] = useState(true);
  const [showModal, setShowModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");
    const [filterData, setFilterData] = useState({});

  const { handleSave, handleAdd, modalCustomizationObject, filterObject, filterFields } = useKanban({
    columns,
    setColumns,
    setErrorMessage,
    setShowModal,
  });

  return (
    <>
      {columns ? (
        <>
          <CustomForm
            fields={filterFields}
            formCustomizationObject={filterObject}
            data={filterData}
            setData={setFilterData}
          />
          <div className="kanban-buttons_container">
            <Button onClick={handleSave} variant="dark">
              Zapisz
            </Button>
            <Button onClick={handleAdd} variant="dark">
              Dodaj
            </Button>
          </div>
          <KanbanBoard columns={columns} setColumns={setColumns} />
          <ModalFormBasic
            fields={fieldsProvider(t).kanbanModalFields}
            data={data}
            setData={setData}
            setIsValid={setIsValid}
            show={showModal}
            setShow={setShowModal}
            modalCustomizationObject={modalCustomizationObject}
            isValid={isValid}
          />
        </>
      ) : (
        <p>Loading...</p>
      )}
      {errorMessage && <p className="text-danger">{errorMessage}</p>}
    </>
  );
};

export default Kanban;
