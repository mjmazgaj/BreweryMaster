import React, { useState } from 'react';
import { login } from '../Authorization/AuthService';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [errorMessage, setErrorMessage] = useState('');
  
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const data = await login({ email, password });
      sessionStorage.setItem('token', data.accessToken);
      setErrorMessage('');
      navigate('/dashboard');
    } catch (error) {
      setErrorMessage(error.response?.data?.message || 'Logowanie nie powiodło się. Spróbuj ponownie.');
    }
  };

  return (
    <form onSubmit={handleLogin}>
      <div>
        <label>Email:</label>
        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>
      <div>
        <label>Hasło:</label>
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </div>
      <button type="submit">Zaloguj</button>
      {errorMessage && <p>{errorMessage}</p>}
    </form>
  );
};

export default Login;
