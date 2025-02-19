import React from "react";

import { Card } from "react-bootstrap";
import { BsArrowRightCircleFill } from "react-icons/bs";

const OrderStatusChanges = ({ statusChanges }) => {
  return (
    statusChanges &&
    statusChanges.length > 0 && (
      <div className="order-status-changes_container">
        <h3>Status change history</h3>
        <div className="order-status-changes_list">
          {statusChanges.map((x, index) => (
            <div key={index} className="order-status-changes_item">
              <Card className="order-status-changes_info">
                <Card.Body>
                  <p>{x.orderStatus}</p>
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
