import React, { Fragment, useState } from "react";
import { Button, Card } from "react-bootstrap";

import { useTranslation } from "react-i18next";

import { useUnitsList } from "./helpers/useUnitsList";
import ModalFormBasic from "../../../Shared/ModalComponents/ModalFormBasic";

const UnitsList = ({ data, refreshPageData }) => {
  const { t } = useTranslation();
  const [units, setUnits] = useState();

  const [editUnits, setEditUnits] = useState({
    itemId: "",
    unitsId: [],
  });
  const [showModal, setShowModal] = useState(false);
  const [modalFields, setModalFields] = useState({});

  const { handleEditUnitsOnClick, modalCustomizationObject } = useUnitsList({
    data,
    setShowModal,
    units,
    setUnits,
    setEditUnits,
    refreshPageData,
    setModalFields,
  });

  return (
    <div>
      <Card className="unit-info_container">
        <Card.Header>
          <h3>Jednostki</h3>
        </Card.Header>

        <Card.Body>
          {data.units ? (
            <Fragment>
              <div className="control-card-units_container">
                {units &&
                  units.map((unit, index) => (
                    <div
                      key={index}
                      className={`control-card-unit ${
                        data.units.includes(unit.id)
                          ? "control-card-unit_include"
                          : ""
                      }`}
                    >
                      {unit.name}
                    </div>
                  ))}
              </div>
              <div className="control-card-buttons_container">
                <Button variant="dark" onClick={handleEditUnitsOnClick}>
                  {t("button.edit")}
                </Button>
              </div>
            </Fragment>
          ) : (
            <div className="control-card-buttons_container">
              <p>Nie ma jednostki</p>
              <Button variant="dark" onClick={() => console.log(units)}>
                {t("button.addNow")}
              </Button>
            </div>
          )}
        </Card.Body>
      </Card>
      <ModalFormBasic
        fields={modalFields}
        data={editUnits}
        setData={setEditUnits}
        show={showModal}
        setShow={setShowModal}
        modalCustomizationObject={modalCustomizationObject}
      />
    </div>
  );
};

export default UnitsList;
