import React, { useState } from "react";
import { Modal, Button } from "react-bootstrap";

import { useTranslation } from "react-i18next";
import { useKanbanModal } from "./helpers/useKanbanModal";
import fieldsProvider from "./helpers/fieldsProvider";

import FormControl from "../../Shared/FormControls";

const KanbanModal = ({ show, setShow, handleClose }) => {
  const { t } = useTranslation();

  const [modalData, setModalData] = useState({
    title: "",
    summary: "",
    status: "",
    ownerId: "",
    orderId: "",
    dueDate: "",
  });

  const [errorMessage, setErrorMessage] = useState("");
  const [isValid, setIsValid] = useState("");

  const { handleUpdate } = useKanbanModal({
    modalData,
    setShow,
    setErrorMessage,
  });

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header>
        <Modal.Title>{t("name.kanban.modalTitle")}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <FormControl
          fields={fieldsProvider(t).kanbanModalFields.control}
          data={modalData}
          setData={setModalData}
          setIsValid={setIsValid}
        />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="dark" onClick={handleClose}>
          {t("button.close")}
        </Button>
        <Button variant="dark" onClick={handleUpdate}>
          {t("button.saveChanges")}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default KanbanModal;
