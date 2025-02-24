import React, { useState } from "react";
import { Button } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

import { useTranslation } from "react-i18next";
import OrderForm from "./OrderComponents/OrderForm";
import OrderTable from "./OrderComponents/OrderTable";

const Order = () => {
  const { t } = useTranslation();
  const [isAddMode, setIsAddMode] = useState(false);
  const [data, setData] = useState([]);

  const handleAddOnClick = () => {
    setIsAddMode(!isAddMode);
  };

  return (
    <div className="order_container">
      <Button
        className="recipe_modeSwitchButton"
        variant="dark"
        onClick={handleAddOnClick}
      >
        {isAddMode ? t("button.back") : t("button.add")}
      </Button>
      {isAddMode ? (
        <OrderForm setData={setData} setIsAddMode={setIsAddMode} />
      ) : (
        <OrderTable data={data} setData={setData} />
      )}
    </div>
  );
};

export default Order;
