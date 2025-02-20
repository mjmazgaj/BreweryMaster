import React, { useState, useEffect } from "react";
import "./user.css";

import { useTranslation } from "react-i18next";

import { useParams } from "react-router-dom";
import fieldsProvider from "../User/helpers/fieldsProvider";

import { fetchData } from "../Shared/api";
import ControlsCard from "../Shared/ControlComponents/ControlsCard";

const UserDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();

  const [data, setData] = useState({});

  useEffect(() => {
    if (id) {
      fetchData(`User/${id}`, setData);
    } else {
      fetchData(`User/Details`, setData);
    }
  }, []);

  return (
    <div className="user-details_container">
      <h2>{t("name.general.details")}</h2>
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
