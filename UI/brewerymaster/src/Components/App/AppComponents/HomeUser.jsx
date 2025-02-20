import "../App.css";
import React, { useState } from "react";
import { useUser } from "../../Security/UserProvider";
import UserDetails from "../../User/UserDetails";
import { Button } from "react-bootstrap";

import { toast } from "react-toastify";
import { useTranslation } from "react-i18next";
import ModalFormBasic from "../../Shared/ModalComponents/ModalFormBasic";

import { updateWithoutParameter } from "../../Shared/api";

import fieldsProvider from "../helpers/fieldsProvider";

const HomeUser = () => {
  const { t } = useTranslation();
  const { user } = useUser();

  const [data, setData] = useState({});

  const [isValid, setIsValid] = useState(false);
  const [showPasswordModal, setShowPasswordModal] = useState(false);

  const handleFormSubmit = (event) => {
    const form = event.currentTarget;
    event.preventDefault();

    if (form.checkValidity() === false || !isValid) {
      event.stopPropagation();
      return false;
    }

    return true;
  };

  const buttons = [
    {
      isSubmit: false,
      function: (event) => {
        if (!handleFormSubmit(event)) {
          return;
        }
        if (data?.password != data?.confirmPassword) {
          toast.error("Potwierdzenie hasła rózni się od nowego hasła");
          return;
        }
        if (data?.password == data?.currentPassword) {
          toast.error("Nowe hasło jest takie samo jak stare");
          return;
        }
        updateWithoutParameter("User/Password", data);
      },
      label: "Save",
    },
  ];

  const handleChangePassword = () => {
    setShowPasswordModal(true);
  };

  return (
    <div className="home-user_container">
      <h3>You are logged as:</h3>
      <p>{user?.email}</p>
      <Button variant="dark" onClick={handleChangePassword}>
        Change password
      </Button>
      <UserDetails />
      <ModalFormBasic
        fields={fieldsProvider(t).passwordModalFields}
        data={data}
        setData={setData}
        setIsValid={setIsValid}
        show={showPasswordModal}
        setShow={setShowPasswordModal}
        title="Edit password"
        submitFunction={() => {}}
        buttons={buttons}
        isValid={isValid}
      />
    </div>
  );
};

export default HomeUser;
