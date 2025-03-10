import "../App.css";
import React, { useState } from "react";
import { useUser } from "../../Security/UserProvider";
import UserDetails from "../../User/UserDetails";
import { Button } from "react-bootstrap";

import { useTranslation } from "react-i18next";
import ModalFormBasic from "../../Shared/ModalComponents/ModalFormBasic";

import fieldsProvider from "../helpers/fieldsProvider";

import { useHomeUser } from "../helpers/useHomeUser";
const HomeUser = () => {
  const { t } = useTranslation();
  const { user } = useUser();

  const [data, setData] = useState({});

  const [showPasswordModal, setShowPasswordModal] = useState(false);

  const { modalCustomizationObject, handleChangePassword } = useHomeUser({
    setShowPasswordModal,
  });

  return (
    <div className="home-user_container">
      <h3>{t("user.loggedAs")}</h3>
      <p>{user?.email}</p>
      <Button variant="dark" onClick={handleChangePassword}>
        {t("button.changePassword")}
      </Button>
      <UserDetails />
      <ModalFormBasic
        fields={fieldsProvider(t).passwordModalFields}
        data={data}
        setData={setData}
        show={showPasswordModal}
        setShow={setShowPasswordModal}
        modalCustomizationObject={modalCustomizationObject}
      />
    </div>
  );
};

export default HomeUser;
