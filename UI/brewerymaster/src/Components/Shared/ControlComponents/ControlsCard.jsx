import React, { Fragment } from "react";

import { Button, Card, CardBody } from "react-bootstrap";
import FormControlsReadOnly from "../FormControlsReadOnly";

import "../shared.css";

import { useTranslation } from "react-i18next";

const ControlsCard = ({
  className,
  title,
  data,
  fields,
  path,
  emptyMessage,
  handleEdit = () => {}
}) => {
  const { t } = useTranslation();

  return (
    <Card className={`control-card_container ${className}`}>
      <Card.Header>
        <h3>{title}</h3>
      </Card.Header>

      <Card.Body>
        {data ? (
          <Fragment>
            <FormControlsReadOnly fields={fields} data={data} />
            <div className="control-card-buttons_container">
              <Button variant="dark" onClick={handleEdit}>
                {t("button.edit")}
              </Button>
            </div>
          </Fragment>
        ) : (
          <div className="control-card-buttons_container">
            <p>{emptyMessage}</p>
            <Button variant="dark">{t("button.addNow")}</Button>
          </div>
        )}
      </Card.Body>
    </Card>
  );
};

export default ControlsCard;
