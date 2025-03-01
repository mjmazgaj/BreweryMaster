import React, { Fragment, useState } from "react";
import { Button, Card } from "react-bootstrap";

import { useTranslation } from "react-i18next";

import fermentingIngredientFieldsProvider from "./helpers/fermentingIngredientFieldsProvider";
import { useUnitsList } from "./helpers/useUnitsList";
import ModalFormBasic from "../../../Shared/ModalComponents/ModalFormBasic";

const UnitsList = ({ data, refreshPageData }) => {
  const { t } = useTranslation();
  const [units, setUnits] = useState();

  const [editUnits, setEditUnits] = useState({});
  const [showModal, setShowModal] = useState(false);

  const { handleEdit, modalCustomizationObject } = useUnitsList({
    data,
    setShowModal,
    setUnits,
    setEditUnits,
    refreshPageData,
  });

  return (
    <Fragment>
      <Card className="unit-info_container">
        <Card.Header>
          <h3>Units</h3>
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
                <Button variant="dark" onClick={handleEdit}>
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
        fields={fermentingIngredientFieldsProvider(t).unitsModal}
        data={editUnits}
        setData={setEditUnits}
        show={showModal}
        setShow={setShowModal}
        modalCustomizationObject={modalCustomizationObject}
      />
    </Fragment>
  );
};

export default UnitsList;
