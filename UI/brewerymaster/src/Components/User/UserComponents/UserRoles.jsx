import React, { Fragment, useState, useEffect } from "react";
import { Button, Card } from "react-bootstrap";

import { useTranslation } from "react-i18next";

import { fetchData } from "../../Shared/api";

const UserRoles = ({ data }) => {
  const { t } = useTranslation();
  const [roles, setRoles] = useState();

  useEffect(() => {
    fetchData("User/Role", setRoles);
  }, []);

  return (
    <Fragment>
      <Card className="user-info_container">
        <Card.Header>
          <h3>Role</h3>
        </Card.Header>

        <Card.Body>
          {data ? (
            <Fragment>
              <div className="control-card-roles_container">
                {roles &&
                  roles.map((role, index) => (
                    <div
                      key={index}
                      className={`control-card-role ${
                        data.includes(role.id)
                          ? "control-card-role_include"
                          : ""
                      }`}
                    >
                      {t(`user.role.${role.name}`)}
                    </div>
                  ))}
              </div>
              <div className="control-card-buttons_container">
                <Button variant="dark" onClick={() => {}}>
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
    </Fragment>
  );
};

export default UserRoles;
