import React, { Fragment } from "react";

import { Button, Card, Form } from "react-bootstrap";

import "../../../Shared/shared.css";

import FormControlReadOnly from "../../../Shared/FormControlsReadOnly";

import { useTranslation } from "react-i18next";
import fermentingIngredientFieldsProvider from "./helpers/fermentingIngredientFieldsProvider";

const FermentingIngredientQuantityCard = ({
  className,
  title,
  data,
  path,
  emptyMessage,
  handleQuantity,
}) => {
  const { t } = useTranslation();

  return (
    <Card className={`fermenting-ingredient-card_container ${className}`}>
      <Card.Header>
        <h3>{title}</h3>
      </Card.Header>

      <Card.Body>
        {data ? (
          <Fragment>
            <FormControlReadOnly
              data={data}
              fields={fermentingIngredientFieldsProvider(t).quantityFields}
            />
            <div className="fermenting-ingredient-card-buttons_container">
              <Button variant="dark" onClick={() => handleQuantity("increase")}>
                {t("button.increase")}
              </Button>
              <Button variant="dark" onClick={() => handleQuantity("reduce")}>
                {t("button.reduce")}
              </Button>
              <Button
                variant="dark"
                onClick={() => handleQuantity("reservation")}
              >
                {t("button.reserve")}
              </Button>
              <Button variant="dark" onClick={() => handleQuantity("order")}>
                {t("button.order")}
              </Button>
            </div>
          </Fragment>
        ) : (
          <div className="fermenting-ingredient-card-empty_container">
            <p>{emptyMessage}</p>
          </div>
        )}
      </Card.Body>
    </Card>
  );
};

export default FermentingIngredientQuantityCard;
