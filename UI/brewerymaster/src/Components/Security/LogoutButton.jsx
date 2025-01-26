import React from 'react';
import { logout } from './Endpoints';
import { useNavigate } from 'react-router-dom';

import { useUser } from './UserProvider';

const LogoutButton = () => {
    const { setUser } = useUser();
    const navigate = useNavigate();

    const handleLogout = () => {
      logout();
      setUser({
        token: [],
        roles: '',
        isAuthenticated: false
      });
      navigate('/login'); 
    };

    return (
      <button onClick={handleLogout}>Wyloguj</button>
    );
  };

  export default LogoutButton;