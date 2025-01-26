import React from 'react';
import { logout } from './Endpoints';
import { useNavigate } from 'react-router-dom';

import { useUser } from './UserProvider';
import { Button } from 'react-bootstrap';

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
      <Button variant="dark" onClick={handleLogout}>
        Wyloguj
      </Button>
    );
  };

  export default LogoutButton;