import React, { useState } from "react";
import { Form, Button, Card } from "react-bootstrap";

import { useLogin } from "./helpers/useLogin";
import securityFormFieldsProvider from "./helpers/securityFormFieldsProvider";
import "bootstrap/dist/css/bootstrap.min.css";
import "./security.css";

import { useTranslation } from "react-i18next";
import FormControls from "../Shared/FormControls";

const Login = () => {
  const { t } = useTranslation();

  const [errorMessage, setErrorMessage] = useState("");

  const [data, setData] = useState({});

  const [isValid, setIsValid] = useState(true);
  const { handleLogin } = useLogin({ data, setErrorMessage });

  return (
    <Form onSubmit={handleLogin}>
      <Card className="login_container">
        <Card.Header>
          <h2>Zaloguj się:</h2>
        </Card.Header>

        <Card.Body>
          <FormControls
            fields={securityFormFieldsProvider(t).loginFields}
            data={data}
            setData={setData}
            setIsValid={setIsValid}
          />
        </Card.Body>

        <Card.Footer>
          <Button variant="dark" type="submit">
            Zaloguj
          </Button>
        </Card.Footer>

        {errorMessage && <p className="text-danger">{errorMessage}</p>}
      </Card>
    </Form>
  );
};

export default Login;
