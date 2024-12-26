import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "../../info.css";

import { useTranslation } from "react-i18next";
import FermentingIngredientsSummary from "./FermentingIngredientsComponents/FermentingIngredientsSummary";
import FermentingIngredientsOrder from "./FermentingIngredientsComponents/FermentingIngredientsOrder";
import FermentingIngredientsReservation from "./FermentingIngredientsComponents/FermentingIngredientsReservation";

import IngredientsMenu from "../IngredientsComponents/IngredientsMenu";

const FermentingIngredients = () => {
  const { t } = useTranslation();

  const [mode, setMode] = useState("summary");


  const steps = {
    "summary":<FermentingIngredientsSummary />,
    "reservation":<FermentingIngredientsReservation />,
    "order":<FermentingIngredientsOrder />,
  }

  return (
    <div className="Info_container">
      <ToastContainer />
      <IngredientsMenu mode={mode} setMode={setMode} />
      {steps[mode]}
    </div>
  );
};

export default FermentingIngredients;
