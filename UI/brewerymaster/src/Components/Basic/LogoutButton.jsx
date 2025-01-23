import React from 'react';
import { logout } from './Endpoints';
import { useNavigate } from 'react-router-dom';

import { useUser } from './UserProvider';

const LogoutButton = ({ setIsAuthenticated }) => {
    const { setUser } = useUser();
    const navigate = useNavigate();

    const handleLogout = () => {
      logout();
      setIsAuthenticated(false);
      setUser({
        token: [],
        roles: '',
      });
      navigate('/login'); 
    };

    return (
      <button onClick={handleLogout}>Wyloguj</button>
    );
  };

  export default LogoutButton;