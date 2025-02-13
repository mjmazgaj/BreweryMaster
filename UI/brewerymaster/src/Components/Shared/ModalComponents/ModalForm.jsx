import React, { useState, useEffect } from "react";
import { Modal, Button, Form } from "react-bootstrap";

import { useModalForm } from "./helpers/useModalForm";
import FormControls from "../FormControls";

import { fetchData } from "../api";
import { useTranslation } from "react-i18next";
import DropDownIndex from "../DropDownIndex";

const ModalForm = ({
  fields,
  data,
  setData,
  units,
  types,
  show,
  setShow,
  action,
  itemName,
}) => {
  const { t } = useTranslation();
  const [isValid, setIsValid] = useState(true);
  const [usedUnits, setUsedUnits] = useState([]);

  const { handleClose, actionObject } = useModalForm({
    data,
    setShow,
    action,
    itemName,
    isValid,
  });

  const handleCheckBox = (unitId, isChecked) => {
    setData((prevData) => ({
        ...prevData,
        units: isChecked ? [...prevData.units, unitId] : 
          prevData.units.filter(x=>x !== unitId)
      }))
  };

  const handleSelectChange = (e) => {
    const { value } = e.target;
    setData((prevData) => ({
      ...prevData,
      typeId: parseInt(value),
    }));
  };

  useEffect(() => {
    if(data?.id && show === true)
      fetchData(`FermentingIngredient/Units/${data.id}`, setUsedUnits);

    if(show === false)
      setUsedUnits([]);
  }, [show]);

  return (
    <Modal show={show} onHide={handleClose}>
      <Form onSubmit={(event) => actionObject.function(event, data)}>
        <Modal.Header closeButton>
          <Modal.Title>{actionObject.title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {types && (
            <DropDownIndex
              id={"modal-form_dropdown"}
              data={types}
              selectedOption={data.typeId}
              setSelectedOption={handleSelectChange}
              isReadOnly={actionObject.isReadOnly}
              label="Type"
            />
          )}
          <FormControls
            fields={fields}
            data={data}
            setData={setData}
            isReadOnly={actionObject.isReadOnly}
            setIsValid={setIsValid}
          />
          {units && (
            <div className="modal-form_checkbox-container">
              <h5>{t("name.brewery.selectUnits")}</h5>
              {units.map((unit) => (
                <Form.Check
                  type="switch"
                  id={`${unit.id}`}
                  key={`${unit.id}`}
                  label={unit.name}
                  checked={usedUnits.includes(unit.id) || data.units?.includes(unit.id)}
                  disabled={usedUnits.includes(unit.id)}
                  onChange={(e) => handleCheckBox(unit.id, e.target.checked)}
                />
              ))}
            </div>
          )}
        </Modal.Body>
        <Modal.Footer>
          <Button type="submit" variant="dark" disabled={!isValid}>
            {action == "add" ? t("button.add") : t("button.saveChanges")}
          </Button>
          <Button variant="dark" onClick={handleClose}>
            {t("button.close")}
          </Button>
        </Modal.Footer>
      </Form>
    </Modal>
  );
};

export default ModalForm;
