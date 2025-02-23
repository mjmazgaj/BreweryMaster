import React from "react";

import { Card } from "react-bootstrap";
import { BsArrowRightCircleFill } from "react-icons/bs";

import { useTranslation } from "react-i18next";

import {lowerCaseFirstLetter} from "../../Shared/helpers/useObjectHelper"

const OrderStatusChanges = ({ statusChanges }) => {
  const { t } = useTranslation();

  return (
    statusChanges &&
    statusChanges.length > 0 && (
      <div className="order-status-changes_container">
        <h3>{t("order.statusChangeHistory")}</h3>
        <div className="order-status-changes_list">
          {statusChanges.map((x, index) => (
            <div key={index} className="order-status-changes_item">
              <Card className="order-status-changes_info">
                <Card.Body>
                  <p>{t(`order.status.${lowerCaseFirstLetter(x.orderStatus)}`)}</p>
                  <p>{x.changedOnDateOnly}</p>
                </Card.Body>
              </Card>
              {index < statusChanges.length - 1 && (
                <div className="order-status-changes_icon">
                  <BsArrowRightCircleFill />
                </div>
              )}
            </div>
          ))}
        </div>
      </div>
    )
  );
};

export default OrderStatusChanges;
