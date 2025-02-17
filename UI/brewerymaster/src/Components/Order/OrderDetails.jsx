import React, { useState, useEffect } from "react";

import { useParams } from "react-router-dom";

import { fetchData } from "../Shared/api";

import { useTranslation } from "react-i18next";
import ControlsCard from "../Shared/ControlComponents/ControlsCard";

import fieldsProviderOrder from "./OrderComponents/helpers/fieldsProvider";
import fieldsProviderRecipe from "../Recipe/RecipeComponents/helpers/fieldsProvider";

const OrderDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();

  const [data, setData] = useState({});

  useEffect(() => {
    fetchData(`Order/Details/${id}`, setData);
  }, []);

  return (
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
  );
};

export default OrderDetails;
