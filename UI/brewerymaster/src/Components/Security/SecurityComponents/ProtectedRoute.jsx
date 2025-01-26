import React from 'react';
import { Navigate } from 'react-router-dom';
import { useUser } from '../UserProvider';

const ProtectedRoute = ({ roles, children }) => {
  const { user } = useUser();

  if(!user.roles || !user.token){
    return <Navigate to="/Unauthorized" replace />;
  }

  const hasAccess = user.roles.some((role) => roles.includes(role));

  if (!hasAccess) {
    return <Navigate to="/Unauthorized" replace />;
  }

  return children;
};

export default ProtectedRoute;
