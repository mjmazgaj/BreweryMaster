import React, { useState, useEffect, Fragment } from "react";
import "./user.css";

import { useTranslation } from "react-i18next";
import { useParams } from "react-router-dom";

import userFieldsProvider from "../User/helpers/userFieldsProvider";
import { fetchData, apiEndpoints } from "../Shared/api";

import ControlsCard from "../Shared/ControlComponents/ControlsCard";
import UserRoles from "./UserComponents/UserRoles";

const UserDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();

  const [userData, setUserData] = useState({});

  const fetchUserDataById = () => {
    fetchData(`${apiEndpoints.user}/${id}`, setUserData);
  };

  const fetchCurrentUserData = () => {
    fetchData(apiEndpoints.userDetails, setUserData);
  };

  useEffect(() => {
    if (id) {
      fetchUserDataById();
    } else {
      fetchCurrentUserData();
    }
  }, []);

  return (
    <div className="user-details_container">
      {id && (
        <Fragment>
          <h2>{t("name.brewery.users")}</h2>
          <h4>{t("name.general.details")}</h4>
        </Fragment>
      )}
      <div className="info_container">
        <ControlsCard
          className="user-info_container"
          title={t("user.userInfoTitle")}
          data={{ ...userData?.individualUser, email: userData?.email }}
          fields={userFieldsProvider(t).infoFields.control}
          path="User"
          emptyMessage={t("user.userInfoEmptyMsg")}
        />
        <ControlsCard
          className="home-address-info_container"
          title={t("user.homeAddressTitle")}
          data={userData?.homeAddress}
          fields={userFieldsProvider(t).addressInfoFields.control}
          path="Address"
          emptyMessage={t("user.homeAddressMsg")}
        />
        <ControlsCard
          className="delivery-address-info_container"
          title={t("user.deliveryAddressTitle")}
          data={userData?.deliveryAddress}
          fields={userFieldsProvider(t).addressInfoFields.control}
          path="Address"
          emptyMessage={t("user.deliveryAddressMsg")}
        />

        {id && <UserRoles userData={userData} refreshPageData={fetchUserDataById}/>}
      </div>
    </div>
  );
};

export default UserDetails;
