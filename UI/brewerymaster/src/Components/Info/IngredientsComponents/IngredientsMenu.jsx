import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "react-toastify/dist/ReactToastify.css";
import "../info.css";

import { Button, ButtonGroup } from "react-bootstrap";

const IngredientsMenu = ({ mode, setMode }) => {
  const handleOnClick = (a) => {
    setMode(a);
  };

  return (
    <div>
      <ButtonGroup>
        <Button
          onClick={() => handleOnClick("summary")}
          variant={mode === "summary" ? "dark" : "secondary"}
        >
          Summary
        </Button>
        <Button
          onClick={() => handleOnClick("order")}
          variant={mode === "order" ? "dark" : "secondary"}
        >
          Orders
        </Button>
        <Button
          onClick={() => handleOnClick("reservation")}
          variant={mode === "reservation" ? "dark" : "secondary"}
        >
          Reservations
        </Button>
      </ButtonGroup>
    </div>
  );
};

export default IngredientsMenu;
