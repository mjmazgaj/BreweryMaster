import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import KanbanBoard from "./KanbanComponents/KanbanBoard";
import "./kanban.css";

import KanbanModal from "./KanbanComponents/KanbanModal";

import { useKanban } from "./KanbanComponents/helpers/useKanban";

const Kanban = () => {
  const [columns, setColumns] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  const { handleSave, handleAdd, handleClose } = useKanban({
    columns,
    setColumns,
    setErrorMessage,
    setShowModal,
  });

  return (
    <>
      {columns ? (
        <>
          <KanbanBoard columns={columns} setColumns={setColumns} />
          <KanbanModal
            show={showModal}
            setShow={setShowModal}
            handleClose={handleClose}
          />
          <div className="kanban-buttons_container">
            <Button onClick={handleSave} variant="dark">
              Zapisz
            </Button>
            <Button onClick={handleAdd} variant="dark">
              Dodaj
            </Button>
          </div>
        </>
      ) : (
        <p>Loading...</p>
      )}
      {errorMessage && <p className="text-danger">{errorMessage}</p>}
    </>
  );
};

export default Kanban;
