import React, {useState} from 'react';
import { Modal, Button, Container, Row, Col } from 'react-bootstrap';

import {addData} from '../../Shared/api';
import { useTranslation } from 'react-i18next';

import FormControl from '../../Shared/FormControls';
const KanbanModal = ({
  show,
  setShow,
  handleClose
}) => {

  const { t } = useTranslation();
  const [modalData, setModalData] = useState({
    title: "",
    summary: "",
    status: "",
    ownerId: "",
    orderId: "",
    dueDate: ""
  });

  const [errorMessage, setErrorMessage] = useState('');
  
  const fields = [
    {
      id: "title",
      label: t("name.kanban.title"),
      type: "text",
    },
    {
      id: "summary",
      label: t("name.kanban.summary"),
      type: "text",
    },
    {
      id: "status",
      label: t("name.kanban.status"),
      type: "number",
    },
    {
      id: "dueDate",
      label: t("name.kanban.dueDate"),
      type: "date",
    },
    {
      id: "ownerId",
      label: t("name.kanban.ownerId"),
      type: "number",
    },
    {
      id: "orderId",
      label: t("name.kanban.orderId"),
      type: "number",
    },
  ];

  const handleUpdate = async (e) => {
    e.preventDefault();

    const task = {
      Title: modalData.title,
      Summary: modalData.summary,
      Status: modalData.status,
      DueDate: modalData.dueDate,
      OwnerId: modalData.ownerId,
      OrderId: modalData.orderId,
    };

    try {
      await addData("task", task);
      setShow(false);
      window.location.reload();
    } catch (error) {
      setErrorMessage(error.response?.data?.message || 'Zapisanie nie powiodło się. Spróbuj ponownie.');
    }
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header>
        <Modal.Title>{t("name.kanban.modalTitle")}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Container>
          <FormControl
            fields={fields}
            data={modalData}
            setData={setModalData}
          />
        </Container>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          {t("button.close")}
        </Button>
        <Button variant="primary" onClick={handleUpdate}>
          {t("button.saveChanges")}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default KanbanModal;
