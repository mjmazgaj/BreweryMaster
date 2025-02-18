import React, { useState, useEffect } from "react";

import { useParams, useNavigate } from "react-router-dom";

import { fetchData } from "../Shared/api";

import { useTranslation } from "react-i18next";
import ControlsCard from "../Shared/ControlComponents/ControlsCard";
import DropDownIndex from "../Shared/DropDownIndex"
import fieldsProviderOrder from "./OrderComponents/helpers/fieldsProvider";
import fieldsProviderRecipe from "../Recipe/RecipeComponents/helpers/fieldsProvider";
import { Button, Card } from "react-bootstrap";

const OrderDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();
  const navigate = useNavigate();

  const [data, setData] = useState({});
  const [editData, setEditData] = useState({
    statusId: 1,
  });
  const [statuses, setStatuses] = useState({});

  const handleButton = () => {
    navigate("/Order");
  };

  
  const handleSelectChange = (e, name) => {
    const { value } = e.target;
    setEditData((prevData) => ({
      ...prevData,
      [name]: parseInt(value),
    }));
  };

  useEffect(() => {
    fetchData(`Order/Details/${id}`, setData);
    fetchData(`Order/Status`, setStatuses);
  }, []);

  return (
    <div className="order-details_container">
      <Button variant="dark" onClick={handleButton}>
        Return
      </Button>

      <div className="order-details-info_container">
        <Card className="order-details-general-info_container">
          <Card.Header>
            <h3>Podsumowanie</h3>
          </Card.Header>
          <Card.Body>
            <p>Receptura: {data?.recipe?.name}</p>
            <p>Zamawiający: {data?.createdBy}</p>
            <p>Termin: {data?.targetDate}</p>

            <DropDownIndex 
            id="test_ID"
            data={statuses}
            selectedOption={editData?.statusId ?? data.statusId}
            setSelectedOption={(e) => {handleSelectChange(e, "statusId")}}
            isReadOnly={false}
            label="Status"
            />
          </Card.Body>
        </Card>
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
