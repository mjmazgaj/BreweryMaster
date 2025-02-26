import React, { Fragment, useState, useEffect } from "react";
import { Button, Card } from "react-bootstrap";

import { useTranslation } from "react-i18next";

import { fetchData, updateData, apiEndpoints } from "../../Shared/api";
import ModalFormBasic from "../../Shared/ModalComponents/ModalFormBasic";

import userFieldsProvider from "../helpers/userFieldsProvider";

const UserRoles = ({ data }) => {
  const { t } = useTranslation();
  const [roles, setRoles] = useState();

  const [editRoles, setEditRoles] = useState({});
  const [showModal, setShowModal] = useState(false);

  const handleEdit = () => {
    setShowModal(true);
    setEditRoles({
      roles: data.roles,
    });
  };

  const modalCustomizationObject = {
    submitFunction: (model) => {
        const requestModel = {
            userId: data.id,
            rolesId: editRoles.roles
        }
        console.log(requestModel)
        updateData("User/Roles", data.id, requestModel)
    },
    buttons: [
      {
        isSubmit: true,
        label: t("button.save"),
      },
    ],
    title: t("user.roleEdit"),
  };

  useEffect(() => {
    fetchData(apiEndpoints.userRole, setRoles);
  }, []);

  return (
    <Fragment>
      <Card className="user-info_container">
        <Card.Header>
          <h3>Role</h3>
        </Card.Header>

        <Card.Body>
          {data.roles ? (
            <Fragment>
              <div className="control-card-roles_container">
                {roles &&
                  roles.map((role, index) => (
                    <div
                      key={index}
                      className={`control-card-role ${
                        data.roles.includes(role.id)
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
