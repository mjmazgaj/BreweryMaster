import React, { useState, useEffect } from "react";
import "./user.css";

import { useTranslation } from "react-i18next";

import { useParams, useNavigate } from "react-router-dom";
import fieldsProvider from "../User/helpers/fieldsProvider";

import { fetchData } from "../Shared/api";
import ControlsCard from "../Shared/ControlComponents/ControlsCard";
import { Button } from "react-bootstrap";

const UserDetails = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();
  const { id } = useParams();

  const [data, setData] = useState({});

  const handleBack = () => {
    navigate("/User");
  };

  useEffect(() => {
    if (id) {
      fetchData(`User/${id}`, setData);
    } else {
      fetchData(`User/Details`, setData);
    }
  }, []);

  return (
    <div className="user-details_container">
      <div className="user-details_buttons-container">
        <Button variant="dark" onClick={handleBack}>
          {t("button.back")}
        </Button>
      </div>
      <h2>{t("name.brewery.users")}</h2>
      <h4>{t("name.general.details")}</h4>
      <div className="info_container">
        <ControlsCard
          className="user-info_container"
          title={t("user.userInfoTitle")}
          data={{ ...data?.individualUser, email: data?.email }}
          fields={fieldsProvider(t).userInfoFields.control}
          path="User"
          emptyMessage={t("user.userInfoEmptyMsg")}
        />
        <ControlsCard
          className="home-address-info_container"
          title={t("user.homeAddressTitle")}
          data={data?.homeAddress}
          fields={fieldsProvider(t).addressInfoFields.control}
          path="Address"
          emptyMessage={t("user.homeAddressMsg")}
        />
        <ControlsCard
          className="delivery-address-info_container"
          title={t("user.deliveryAddressTitle")}
          data={data?.deliveryAddress}
          fields={fieldsProvider(t).addressInfoFields.control}
          path="Address"
          emptyMessage={t("user.deliveryAddressMsg")}
        />
      </div>
    </div>
  );
};

export default UserDetails;
