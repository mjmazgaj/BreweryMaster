import React, { Fragment } from "react";

import { Button, Card, Form } from "react-bootstrap";

import "../../../Shared/shared.css";

import FormControlReadOnly from "../../../Shared/FormControlsReadOnly";

import { useTranslation } from "react-i18next";
import fermentingIngredientFieldsProvider from "./helpers/fermentingIngredientFieldsProvider";
import { PieChart, Pie, Cell, Tooltip, Legend } from "recharts";

const FermentingIngredientQuantityCard = ({
  className,
  title,
  data,
  path,
  emptyMessage,
}) => {
  const { t } = useTranslation();

  const handleIncrease = () => {
    console.log("Increase works");
    console.log("Path");
    console.log(path);
  };

  const handleReduce = () => {
    console.log("Reduce works");
    console.log("Path");
    console.log(path);
  };

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
              <Form.Label>{t("fermentingIngredient.changeStorage")}</Form.Label>
              <div className="fermenting-ingredient-card-storage-buttons_container">
                <Button variant="dark" onClick={handleIncrease}>
                  {t("button.increase")}
                </Button>
                <Button variant="dark" onClick={handleReduce}>
                  {t("button.reduce")}
                </Button>
              </div>
              <Form.Label>
                {t("fermentingIngredient.orderOrReserve")}
              </Form.Label>
              <div className="fermenting-ingredient-card-order-buttons_container">
                <Button variant="dark" onClick={handleIncrease}>
                  {t("button.reserve")}
                </Button>
                <Button variant="dark" onClick={handleReduce}>
                  {t("button.order")}
                </Button>
              </div>
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
