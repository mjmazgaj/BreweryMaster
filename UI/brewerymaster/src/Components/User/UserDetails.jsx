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
      <h2>Details</h2>
      <div className="info_container">
        <ControlsCard
          className="user-info_container"
          title="User info"
          data={{ ...data?.individualUser, email: data?.email }}
          fields={fieldsProvider(t).userInfoFields.control}
          path="User"
          emptyMessage="User info can't be loaded"
        />
        <ControlsCard
          className="home-address-info_container"
          title="Home address info"
          data={data?.homeAddress}
          fields={fieldsProvider(t).addressInfoFields.control}
          path="Address"
          emptyMessage="Home address wasn't added"
        />
        <ControlsCard
          className="delivery-address-info_container"
          title="Delivery address info"
          data={data?.deliveryAddress}
          fields={fieldsProvider(t).addressInfoFields.control}
          path="Address"
          emptyMessage="Delivery address wasn't added"
        />
      </div>
    </div>
  );
};

export default UserDetails;
