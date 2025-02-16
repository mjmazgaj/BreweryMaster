import React, { useState, useEffect } from "react";
import "./user.css";

import { useTranslation } from "react-i18next";
import { useUser } from "../Security/UserProvider";

import fieldsProvider from "../User/helpers/fieldsProvider";
import FormControlsReadOnly from "../Shared/FormControlsReadOnly";
import { Button } from "react-bootstrap";

import { fetchData } from "../Shared/api";

const UserDetails = () => {
  const { t } = useTranslation();
  const { user } = useUser();

  const [data, setData] = useState({});

  
    useEffect(() => {
      fetchData(`User/Details`, setData);
    }, []);

  return (
    <div className="user-details_container">
      <h3>You are logged as:</h3>
      <p>{user?.email}</p>
      <h2>Details</h2>
      <div className="info_container">
        <div className="user-info_container">
          <h3>User info</h3>
          <FormControlsReadOnly
            fields={fieldsProvider(t).userInfoFields.control}
            data={{...data.individualUser, email:data.email}}
          />
          <div className="buttons_container">
            <Button variant="dark">Edit</Button>
            <Button variant="dark">Change password</Button>
          </div>
        </div>
        <div className="home-address-info_container">
          <h3>Home address info</h3>
          <FormControlsReadOnly
            fields={fieldsProvider(t).addressInfoFields.control}
            data={data.homeAddress}
          />
          <div className="buttons_container">
            <Button variant="dark">Edit</Button>
          </div>
        </div>
        <div className="delivery-address-info_container">
          <h3>Delivery address info</h3>
          <FormControlsReadOnly
            fields={fieldsProvider(t).addressInfoFields.control}
            data={data.deliveryAddress}
          />
          <div className="buttons_container">
            <Button variant="dark">Edit</Button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default UserDetails;
