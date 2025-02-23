import React, { useState, useEffect } from "react";

import { useParams, useNavigate } from "react-router-dom";

import { addData, fetchData } from "../Shared/api";

import { useTranslation } from "react-i18next";
import ControlsCard from "../Shared/ControlComponents/ControlsCard";
import DropDownIndex from "../Shared/DropDownIndex";
import OrderStatusChanges from "./OrderComponents/OrderStatusChanges";
import fieldsProviderOrder from "./OrderComponents/helpers/fieldsProvider";
import fieldsProviderRecipe from "../Recipe/RecipeComponents/helpers/fieldsProvider";
import { Button, Card } from "react-bootstrap";

import { lowerCaseFirstLetter } from "../Shared/helpers/useObjectHelper";

const OrderDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();
  const navigate = useNavigate();

  const [data, setData] = useState({});
  const [editData, setEditData] = useState({});
  const [statuses, setStatuses] = useState({});

  const handleButton = () => {
    navigate("/Order");
  };

  const handleAddTasks = () => {
    const newData = {
      orderId: data.id,
      orderStatus: data.statusId,
    };

    addData("Task/Template", newData);
  };

  const handleSelectChange = (e, name) => {
    const { value } = e.target;

    let statusId = parseInt(value);

    if (statusId == 0 || statusId === editData.statusId) return;

    setEditData((prevData) => ({
      ...prevData,
      [name]: statusId,
    }));

    addData("Order/Status", {
      orderId: data.id,
      orderStatusId: statusId,
    });
  };

  useEffect(() => {
    fetchData(`Order/Details/${id}`, setData);
    fetchData(`Order/Status`, setStatuses);

    setEditData((prevData) => ({
      ...prevData,
      statusId: data.statusId,
    }));
  }, []);

  return (
    <div className="order-details_container">
      <Button variant="dark" onClick={handleButton}>
        {t("button.back")}
      </Button>

      <OrderStatusChanges statusChanges={data.statusChanges} />

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
              data={
                statuses &&
                statuses.length > 0 &&
                statuses.map((x) => ({
                  ...x,
                  name: t(`order.status.${lowerCaseFirstLetter(x.name)}`),
                }))
              }
              selectedOption={editData?.statusId ?? data.statusId}
              setSelectedOption={(e) => {
                handleSelectChange(e, "statusId");
              }}
              isReadOnly={false}
              label="Status"
            />
          </Card.Body>
          <Card.Footer>
            <Button variant="dark" onClick={handleAddTasks}>
              {t("button.generateTasks")}
            </Button>
          </Card.Footer>
        </Card>
        <ControlsCard
          className="order-details-general-info_container"
          title={t("name.general.details")}
          data={data}
          fields={fieldsProviderOrder(t).orderGeneralInfoFields.control}
          path=""
          emptyMessage=""
        />
        <ControlsCard
          className="order-details-recipe-info_container"
          title={t("name.general.recipe")}
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
