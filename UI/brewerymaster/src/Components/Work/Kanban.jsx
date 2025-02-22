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

  const { handleSave, handleAdd, modalCustomizationObject, formCustomizationObject } = useKanban({
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
            fields={fieldsProvider(t).filterFields}
            formCustomizationObject={formCustomizationObject}
          />
          <KanbanBoard columns={columns} setColumns={setColumns} />
          <div className="kanban-buttons_container">
            <Button onClick={handleSave} variant="dark">
              Zapisz
            </Button>
            <Button onClick={handleAdd} variant="dark">
              Dodaj
            </Button>
          </div>
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
