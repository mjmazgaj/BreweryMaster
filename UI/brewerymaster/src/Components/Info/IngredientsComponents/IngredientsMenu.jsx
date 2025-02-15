import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "react-toastify/dist/ReactToastify.css";
import "../info.css";

import { Button, ButtonGroup } from "react-bootstrap";

import { useTranslation } from "react-i18next";
const IngredientsMenu = ({ mode, setMode }) => {
  const { t } = useTranslation();
  const handleOnClick = (a) => {
    setMode(a);
  };

  return (
    <div className="ingredients-menu__container">
      <ButtonGroup>
        <Button
          onClick={() => handleOnClick("summary")}
          variant={mode === "summary" ? "dark" : "secondary"}
        >
          {t("button.summary")}
        </Button>
        <Button
          onClick={() => handleOnClick("order")}
          variant={mode === "order" ? "dark" : "secondary"}
        >
          {t("button.orders")}
        </Button>
        <Button
          onClick={() => handleOnClick("reservation")}
          variant={mode === "reservation" ? "dark" : "secondary"}
        >
          {t("button.reservations")}
        </Button>
      </ButtonGroup>
    </div>
  );
};

export default IngredientsMenu;
