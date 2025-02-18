import React, { useState, useEffect } from "react";

import { useParams, useNavigate } from "react-router-dom";

import { fetchData } from "../Shared/api";

import { useTranslation } from "react-i18next";
import ControlsCard from "../Shared/ControlComponents/ControlsCard";

import fieldsProviderOrder from "./OrderComponents/helpers/fieldsProvider";
import fieldsProviderRecipe from "../Recipe/RecipeComponents/helpers/fieldsProvider";
import { Button } from "react-bootstrap";

const OrderDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();
  const navigate = useNavigate();

  const [data, setData] = useState({});

  const handleButton = () => {
    navigate("/Order");
  };

  useEffect(() => {
    fetchData(`Order/Details/${id}`, setData);
  }, []);

  return (
    <div className="order-details_container">
      <Button variant="dark" onClick={handleButton}>
        Return
      </Button>
      <h4>Szczegóły na temat zamówienia</h4>
      <p>Receptura: {data?.recipe?.name}</p>
      <p>Zamawiający: {data?.createdBy}</p>
      <p>Termin: {data?.targetDate}</p>

      <div className="order-details-info_container">
        <ControlsCard
          className="order-details-general-info_container"
          title="General Info"
          data={data}
          fields={fieldsProviderOrder(t).orderGeneralInfoFields.control}
          path=""
          emptyMessage=""
        />
        <ControlsCard
          className="order-details-recipe-info_container"
          title="Recipe"
          data={data.recipe}
          fields={fieldsProviderRecipe(t).recipeGeneralInfoFields.control}
          path=""
          emptyMessage=""
        />
      </div>
    </div>
  );
};

export default OrderDetails;
