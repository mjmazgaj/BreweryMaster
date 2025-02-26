import React, { Fragment, useState } from "react";
import { Button, Card } from "react-bootstrap";

import { useTranslation } from "react-i18next";

import userFieldsProvider from "../helpers/userFieldsProvider";
import { useUserRoles } from "./helpers/useUserRoles";
import ModalFormBasic from "../../Shared/ModalComponents/ModalFormBasic";

const UserRoles = ({ userData, refreshPageData }) => {
  const { t } = useTranslation();
  const [roles, setRoles] = useState();

  const [editRoles, setEditRoles] = useState({});
  const [showModal, setShowModal] = useState(false);

  const { handleEdit, modalCustomizationObject } = useUserRoles({
    userData,
    setShowModal,
    setRoles,
    setEditRoles,
    refreshPageData
  });

  return (
    <Fragment>
      <Card className="user-info_container">
        <Card.Header>
          <h3>Role</h3>
        </Card.Header>

        <Card.Body>
          {userData.roles ? (
            <Fragment>
              <div className="control-card-roles_container">
                {roles &&
                  roles.map((role, index) => (
                    <div
                      key={index}
                      className={`control-card-role ${
                        userData.roles.includes(role.id)
                          ? "control-card-role_include"
                          : ""
                      }`}
                    >
                      {t(`user.role.${role.name}`)}
                    </div>
                  ))}
              </div>
              <div className="control-card-buttons_container">
                <Button variant="dark" onClick={handleEdit}>
                  {t("button.edit")}
                </Button>
              </div>
            </Fragment>
          ) : (
            <div className="control-card-buttons_container">
              <p>Nie ma roli</p>
              <Button variant="dark">{t("button.addNow")}</Button>
            </div>
          )}
        </Card.Body>
      </Card>
      <ModalFormBasic
        fields={userFieldsProvider(t).rolesModal}
        data={editRoles}
        setData={setEditRoles}
        show={showModal}
        setShow={setShowModal}
        modalCustomizationObject={modalCustomizationObject}
      />
    </Fragment>
  );
};

export default UserRoles;
