import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import "./kanban.css";

import { useTranslation } from "react-i18next";
import { useKanban } from "./KanbanComponents/helpers/useKanban";

import kanbanFieldsProvider from "./KanbanComponents/helpers/kanbanFieldsProvider";

import KanbanBoard from "./KanbanComponents/KanbanBoard";
import ModalFormBasic from "../Shared/ModalComponents/ModalFormBasic";
import CustomForm from "../Shared/CustomForm";
import ModalConfirmationBasic from "../Shared/ModalComponents/ModalConfirmationBasic";

const Kanban = () => {
  const { t } = useTranslation();
  const [columns, setColumns] = useState(null);
  const [modalData, setModalData] = useState({});
  const [showAddModal, setShowAddModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [filterData, setFilterData] = useState({});

  const {
    handleSave,
    handleAdd,
    addModalObject,
    editModalObject,
    editModalFields,
    deleteModalObject,
    filterObject,
    filterFields,
  } = useKanban({
    columns,
    setColumns,
    setShowAddModal,
    setShowDeleteModal,
    modalData,
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
            setShowDeleteModal={setShowDeleteModal}
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
            fields={editModalFields}
            data={modalData}
            setData={setModalData}
            show={showEditModal}
            setShow={setShowEditModal}
            modalCustomizationObject={editModalObject}
          />
          <ModalConfirmationBasic
            show={showDeleteModal}
            setShow={setShowDeleteModal}
            modalCustomizationObject={deleteModalObject}
          />
        </>
      ) : (
        <p>Loading...</p>
      )}
    </>
  );
};

export default Kanban;
