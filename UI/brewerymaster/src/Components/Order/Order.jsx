import React, { useState } from "react";
import { Button } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

import OrderForm from "./OrderComponents/OrderForm";
import OrderTable from "./OrderComponents/OrderTable";

const Order = () => {
  const [isAddMode, setIsAddMode] = useState(false);

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
        {isAddMode ? "Show all orders" : "Add Order"}
      </Button>
      {isAddMode ? <OrderForm /> : <OrderTable />}
    </div>
  );
};

export default Order;
