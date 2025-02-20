import React, { useState, useEffect } from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalItemAction } from "./helpers/useModalItemAction";
import FormControlsReadOnly from "../FormControlsReadOnly";

import { useTranslation } from "react-i18next";
import { fetchData } from "../api";

const ModalItemAction = ({
  fields,
  data,
  show,
  setShow,
  setShowConfirmationModal,
  setShowQuantityModal,
  setShowModalForm,
  setModalAction,
  setQuantityAction,
  action,
  setAction,
}) => {
  const { t } = useTranslation();
  const [units, setUnits] = useState([]);

  const { handleClose, handleDelete, handleEdit, actionObject } =
    useModalItemAction({
      data,
      setShow,
      setShowConfirmationModal,
      setShowQuantityModal,
      setShowModalForm,
      setModalAction,
      setQuantityAction,
      action,
    });

  const buttonsSet = {
    default: (
      <>
        <Button variant="dark" onClick={handleEdit}>
          {t("button.edit")}
        </Button>
        <Button variant="dark" onClick={handleDelete}>
          {t("button.delete")}
        </Button>
      </>
    ),
    summary: (
      <>
        <Button
          variant="dark"
          onClick={actionObject.function(data, "storage", "Increase")}
        >
          {t("button.increase")}
        </Button>
        <Button
          variant="dark"
          onClick={actionObject.function(data, "storage", "Reduce")}
        >
          {t("button.reduce")}
        </Button>
        <Button
          variant="dark"
          onClick={actionObject.function(data, "reservation")}
        >
          {t("button.reserve")}
        </Button>
        <Button variant="dark" onClick={actionObject.function(data, "order")}>
          {t("button.order")}
        </Button>
        <Button variant="dark" onClick={handleEdit}>
          {t("button.edit")}
        </Button>
        <Button variant="dark" onClick={handleDelete}>
          {t("button.delete")}
        </Button>
      </>
    ),
  };

  useEffect(() => {
    fetchData("Entity/Unit", setUnits);
  }, []);

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{actionObject.title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <FormControlsReadOnly fields={fields} data={data} />
      </Modal.Body>
      <Modal.Footer>
        {buttonsSet[action]}
        <Button variant="dark" onClick={handleClose}>
          {t("button.close")}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalItemAction;
