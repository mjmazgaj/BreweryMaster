import React, { useState } from 'react';
import { register } from '../Authorization/AuthService';
import { useNavigate } from 'react-router-dom';

const Register = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  const navigate = useNavigate();

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
      await register({ email: email, password: password });
      setErrorMessage('');
      navigate('/login');
    } catch (error) {
      setErrorMessage(error.response?.data?.message || 'Rejestracja nie powiodła się. Spróbuj ponownie.');
    }
  };

  return (
    <form onSubmit={handleRegister}>
      <div>
        <label>Email:</label>
        <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
      </div>
      <div>
        <label>Password:</label>
        <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
      </div>
      <button type="submit">Register</button>
      {errorMessage && <p>{errorMessage}</p>}
    </form>
  );
};

export default Register;
