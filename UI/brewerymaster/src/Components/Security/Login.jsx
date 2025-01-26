import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';

import { useLogin } from './helpers/useLogin';
import securityFormFieldsProvider from './helpers/securityFormFieldsProvider';
import 'bootstrap/dist/css/bootstrap.min.css';

import { useTranslation } from 'react-i18next';
import FormControls from '../Shared/FormControls'

const Login = () => {

  const { t } = useTranslation();
  
  const [errorMessage, setErrorMessage] = useState('');

  const [data, setData] = useState({});

  const [isValid, setIsValid] = useState(true);
  const { handleLogin } = useLogin({ data, setErrorMessage });

  return (
    <Form onSubmit={handleLogin}>
      <h1>Zaloguj się:</h1>

      <FormControls
        fields={securityFormFieldsProvider(t).loginFields}
        data={data}
        setData={setData}
        setIsValid={setIsValid}
      />

      <Button variant="dark" type="submit">
        Zaloguj
      </Button>

      {errorMessage && <p className="text-danger">{errorMessage}</p>}
    </Form>
  );
};

export default Login;
