import React from 'react';
import { useUser } from './UserProvider';

const RequireRole = ({ roles, children }) => {
  const { user } = useUser();
  
  if (!user?.roles) {
    return null;
  }

  const hasAccess = user.roles.some((role) => roles.includes(role));

  if (!hasAccess) {
    return null;
  }

  return <>{children}</>;
};

export default RequireRole;
