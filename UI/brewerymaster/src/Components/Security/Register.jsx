import React, { useState, Fragment } from "react";

import { useRegister } from "./helpers/useRegister";

import { useTranslation } from "react-i18next";

import FormCarousel from "../Shared/FormCarousel";
import "bootstrap/dist/css/bootstrap.min.css";
import { Card } from "react-bootstrap";

const Register = () => {
  const { t } = useTranslation();
  const [errorMessage, setErrorMessage] = useState("");

  const [isValid, setIsValid] = useState(true);
  const { handleRegister, steps } = useRegister({
    setErrorMessage,
    setIsValid,
  });

  return (
    <Fragment>
      <Card className="register_container">
        <Card.Header>
          <h2>Zarejestruj się:</h2>
        </Card.Header>
        <Card.Body>
          <FormCarousel
            steps={steps}
            handleSave={handleRegister}
            isValid={isValid}
          />
        </Card.Body>
      </Card>
      {errorMessage && <p className="text-danger">{errorMessage}</p>}
    </Fragment>
  );
};

export default Register;
