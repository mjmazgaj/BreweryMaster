import React from "react";

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
}) => {
  const { t } = useTranslation();

  const handleEdit = () => {
    console.log("Edit works");
    console.log("Path");
    console.log(path);
  };

  return (
    <Card className={`control-card_container ${className}`}>
      <Card.Header>
        <h3>{title}</h3>
      </Card.Header>

      {data ? (
        <Card.Body>
          <FormControlsReadOnly fields={fields} data={data} />
          <div className="control-card-buttons_container">
            <Button variant="dark" onClick={handleEdit}>
              {t("button.edit")}
            </Button>
          </div>
        </Card.Body>
      ) : (
        <div className="control-card-buttons_container">
          <p>{emptyMessage}</p>
          <Button variant="dark">{t("button.addNow")}</Button>
        </div>
      )}
    </Card>
  );
};

export default ControlsCard;
