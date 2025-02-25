import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import "./kanban.css";

import { useTranslation } from "react-i18next";
import { useKanban } from "./KanbanComponents/helpers/useKanban";

import kanbanFieldsProvider from "./KanbanComponents/helpers/kanbanFieldsProvider";

import KanbanBoard from "./KanbanComponents/KanbanBoard";
import ModalFormBasic from "../Shared/ModalComponents/ModalFormBasic";
import CustomForm from "../Shared/CustomForm";

const Kanban = () => {
  const { t } = useTranslation();
  const [columns, setColumns] = useState(null);
  const [modalData, setModalData] = useState({});
  const [showAddModal, setShowAddModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);
  const [filterData, setFilterData] = useState({});

  const {
    handleSave,
    handleAdd,
    addModalObject,
    editModalObject,
    filterObject,
    filterFields,
  } = useKanban({
    columns,
    setColumns,
    setShowAddModal,
    setModalData,
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
              {t("button.save")}
            </Button>
            <Button onClick={handleAdd} variant="dark">
              {t("button.add")}
            </Button>
          </div>
          <KanbanBoard
            columns={columns}
            setColumns={setColumns}
            setShowEditModal={setShowEditModal}
            setModalData={setModalData}
          />
          <ModalFormBasic
            fields={kanbanFieldsProvider(t).modalFields}
            data={modalData}
            setData={setModalData}
            show={showAddModal}
            setShow={setShowAddModal}
            modalCustomizationObject={addModalObject}
          />
          <ModalFormBasic
            fields={kanbanFieldsProvider(t).modalFields}
            data={modalData}
            setData={setModalData}
            show={showEditModal}
            setShow={setShowEditModal}
            modalCustomizationObject={editModalObject}
          />
        </>
      ) : (
        <p>Loading...</p>
      )}
    </>
  );
};

export default Kanban;
